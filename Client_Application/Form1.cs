using System;
using System.Windows.Forms;
using System.Threading;
using QuickFix;
using NLog;
using OxyPlot;
using OxyPlot.Series;

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

        #endregion
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
                var myModel = new PlotModel();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }
        }

        // Used for Getting Data from the Exchange Server and saving it to an excel file
        private void bStartApp_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                initiator.Start();
                Thread.Sleep(1000);
                application.StartExcel(dataFile);
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
                if (initiator.IsLoggedOn && application.MarketDataGet)
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
            }
            catch (Exception error)
            {
                logger.Error(error.Message);
                logger.Error(error.StackTrace);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbDisplay.Text += application.Data;
            tbDisplay.SelectionStart = tbDisplay.Text.Length;
            tbDisplay.ScrollToCaret();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lProfit.Text = "Profit: " + application.Profit.ToString("C");
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
                dOrderTable.Rows[count].Cells[3].Value = trade.CumQty.ToString();
                dOrderTable.Rows[count++].Cells[4].Value = (trade.Side.getValue() == '1')? "Buy":"Sell";
            }
            if (count > 0) { dOrderTable.RowCount = count; }
        }
    }
}
