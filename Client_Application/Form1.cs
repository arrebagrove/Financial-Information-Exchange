﻿using System;
using System.Windows.Forms;
using System.Threading;
using QuickFix;
using NLog;
using MathNet.Numerics.Statistics;
using System.Collections.Generic;

namespace Client_Application
{
    public partial class Form1 : Form
    {
        #region Variables

        private const string configFile = "Client.cfg";
        private const string dataFile = "C:\\Users\\aban20\\Desktop\\MarketData.xlsx";
        private Client application = new Client(true);
        private SessionSettings settings;
        private IMessageStoreFactory storeFactory;
        private ILogFactory logFactory;
        private QuickFix.Transport.SocketInitiator initiator;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string startTime = DateTime.Now.ToString("h:mm:ss tt");

        #endregion

        #region Form
        public Form1()
        {
            InitializeComponent();
            tbDisplay.ReadOnly = true;
            tbDisplay.ScrollBars = ScrollBars.Vertical;
            try
            {
                settings = new SessionSettings(configFile);
                storeFactory = new FileStoreFactory(settings);
                logFactory = new ScreenLogFactory(settings);
                initiator = new QuickFix.Transport.SocketInitiator(application, storeFactory, settings, logFactory);
                timer1.Interval = 1000;
                timer2.Interval = 500;
                timer3.Interval = 1000;
                timer4.Interval = 500;
                PricePlot.ChartAreas[0].AxisX.Minimum = 0;
                cBuyingSelling.ChartAreas[0].AxisX.Minimum = 0;
                cBuyingSelling.ChartAreas[1].AxisX.Minimum = 0;
                PricePlot.ChartAreas[1].AxisX.Minimum = 0;
                PricePlot.ChartAreas[2].AxisX.Minimum = 0;
                PricePlot.ChartAreas[0].AxisY.Title = "Price";
                PricePlot.ChartAreas[1].AxisY.Title = "Price On Average";
                PricePlot.ChartAreas[1].AxisY.Title = "Price after removing Trend";
                PricePlot.ChartAreas[1].Visible = false;
                PricePlot.ChartAreas[2].Visible = false;
                ltime.ForeColor = System.Drawing.Color.Blue;
                runningTIme.ForeColor = System.Drawing.Color.Blue;
                runningTIme.Text = "Running Time: 0 Second";
                String currentTime = DateTime.Now.ToString("h:mm:ss tt");
                ltime.Text = "Current Time: " + currentTime;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }
        }

        #endregion

        #region Buttons

        // Used for Getting Data from the Exchange Server and saving it to an excel file
        private void bStartApp_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                timer4.Enabled = true;
                initiator.Start();
                Thread.Sleep(1000);
                if (initiator.IsLoggedOn) { application.StartExcel(dataFile); }
            }
            catch (Exception error)
            {
                logger.Error(error.Message);
                logger.Error(error.StackTrace);
            }
        }

        // Used to stop the client
        private void bStop_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                if (initiator.IsLoggedOn)
                {
                    application.CloseExcel();
                }
                initiator.Stop();
            }
            catch (Exception error)
            {
                logger.Error(error.Message);
                logger.Error(error.StackTrace);
            }

        }

        // Used to start trading based on the algorithm we design
        private void bTradeAuto_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;
            try
            {
                if (initiator.IsLoggedOn && application.MarketDataGet)
                {
                    application.CloseExcel();
                    initiator.Stop();
                    Thread.Sleep(1000);
                }
                application.MarketDataGet = false;
                initiator.Start();
                Thread.Sleep(1000);
                if (initiator.IsLoggedOn) { application.StartExcel(dataFile); }
            }
            catch (Exception error)
            {
                logger.Error(error.Message);
                logger.Error(error.StackTrace);
            }
            
        }

        #endregion

        #region Timers
        private void timer1_Tick(object sender, EventArgs e)
        {
            tbDisplay.Text += application.Data;
            tbDisplay.SelectionStart = tbDisplay.Text.Length;
            tbDisplay.ScrollToCaret();
            String currentTime = DateTime.Now.ToString("h:mm:ss tt");
            ltime.Text = "Current Time: " + currentTime;
            runningTIme.Text = "Running Time: " + DateTime.Parse(currentTime).Subtract(DateTime.Parse(startTime));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lProfit.Text = "Profit: " + application.Profit.ToString("C");
            lPosition.Text = "Position: " + application.TotalOrders;
            if (application.Profit < 0)
            {
                lProfit.ForeColor = System.Drawing.Color.Red;
            }
            else if (application.Profit > 0)
            {
                lProfit.ForeColor = System.Drawing.Color.Green;
            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            QuickFix.FIX44.ExecutionReport[] trades = new QuickFix.FIX44.ExecutionReport[application.trades.Count];
            application.trades.CopyTo(trades);
            int count = 0;
            foreach (QuickFix.FIX44.ExecutionReport trade in trades)
            {
                dOrderTable.Rows.Add();
                dOrderTable.Rows[count].Cells[0].Value = trade.Header.GetDateTime(52).ToString();
                dOrderTable.Rows[count].Cells[1].Value = trade.Symbol.ToString();
                dOrderTable.Rows[count].Cells[2].Value = trade.Price.getValue().ToString();
                dOrderTable.Rows[count].Cells[3].Value = trade.CumQty.getValue().ToString();
                dOrderTable.Rows[count++].Cells[4].Value = (trade.Side.getValue() == '1')? "Buy":"Sell";
            }
            if (count > 0) { dOrderTable.RowCount = count; }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                int shortPeriod = 50;int trendPeriod = 990; // Trend Period Came from Analysis of the Data
                int longPeriod = 200;
                List<Double> price = new List<double>(application.AskPrices);
                Dictionary<int, Double> buyingPoints = new Dictionary<int, Double>(application.BuyingPrices);
                Dictionary<int, Double> sellingPoints = new Dictionary<int, Double>(application.SellingPrices);
                foreach (var series in PricePlot.Series){ series.Points.Clear(); }
                foreach (var series in cBuyingSelling.Series) { series.Points.Clear(); }
                for (int i = 0; i < price.Count; i++){ PricePlot.Series[0].Points.AddXY(i, price[i]); }
                for (int i = 0; i < price.Count; i++) { cBuyingSelling.Series[0].Points.AddXY(i, price[i]); }
                foreach (int key in buyingPoints.Keys) { cBuyingSelling.Series[3].Points.AddXY(key-1, buyingPoints[key]); }
                foreach (int key in sellingPoints.Keys) { cBuyingSelling.Series[4].Points.AddXY(key-1, sellingPoints[key]); }
                if (price.Count > 500)
                {
                    cBuyingSelling.ChartAreas[0].AxisX.Minimum = price.Count - 500;
                    cBuyingSelling.ChartAreas[1].AxisX.Minimum = price.Count - 500;
                }
                if (price.Count >= shortPeriod)
                {
                    List<double> priceMa = application.getMovingAverage(shortPeriod);
                    for (int i = shortPeriod; i < price.Count; i++) { cBuyingSelling.Series[1].Points.AddXY(i, priceMa[i]); }
                }
                if (price.Count >= longPeriod)
                {
                    List<double> priceMa = application.getMovingAverage(longPeriod);
                    for (int i = longPeriod; i < price.Count; i++) { cBuyingSelling.Series[2].Points.AddXY(i, priceMa[i]); }
                }
                if (application.Strategy.MacdLine.Count >= 9)
                {
                    cBuyingSelling.ChartAreas[1].Visible = true;
                    List<double> macdLine = application.Strategy.MacdLine;
                    List<double> signalLine = application.Strategy.SignalLine;
                    for (int i = 26; i < 26+macdLine.Count; i++) { cBuyingSelling.Series[5].Points.AddXY(i, macdLine[i-26]); }
                    for (int i = 34; i < 34+signalLine.Count; i++) { cBuyingSelling.Series[6].Points.AddXY(i, signalLine[i-34]); }
                    PricePlot.ChartAreas[2].AxisY.Minimum = macdLine.Minimum() - 0.5;
                    PricePlot.ChartAreas[2].AxisY.Maximum = macdLine.Maximum() + 0.5;
                }


                if (price.Count >= trendPeriod)
                {
                    PricePlot.ChartAreas[1].Visible = true;
                    PricePlot.ChartAreas[2].Visible = true;
                    List<double> trend = application.getMovingAverage(trendPeriod);
                    for (int i = trendPeriod; i < price.Count; i++) { PricePlot.Series[1].Points.AddXY(i, trend[i]); }
                    for (int i = trendPeriod; i < price.Count; i++) { PricePlot.Series[2].Points.AddXY(i, price[i]/trend[i]); }
                    PricePlot.ChartAreas[1].AxisY.Minimum = trend.Minimum() - 1;
                    PricePlot.ChartAreas[1].AxisY.Maximum = trend.Maximum() + 1;
                    PricePlot.ChartAreas[2].AxisY.Minimum = 0.95;
                    PricePlot.ChartAreas[2].AxisY.Maximum = 1.065;
                }

                PricePlot.ChartAreas[0].AxisY.Minimum = price.Minimum() - 1;
                cBuyingSelling.ChartAreas[0].AxisY.Minimum = price.Minimum() - 1;
                PricePlot.ChartAreas[0].AxisY.Maximum = price.Maximum() + 1;
                cBuyingSelling.ChartAreas[0].AxisY.Maximum = price.Maximum() + 1;

            }
            catch (Exception error)
            {
                logger.Error(error.Message);
                logger.Error(error.StackTrace);
            }                 
        }


        #endregion

    }
}
