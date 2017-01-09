using System;
using System.Windows.Forms;
using System.Threading;
using QuickFix;
using NLog;

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
                timer2.Interval = 10000;
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
                timer2.Enabled = false;
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
            lProfit.Text = "Profit: $" + application.Profit;
            if (application.Profit < 0)
            {
                lProfit.ForeColor = System.Drawing.Color.Red;
            }
            else if (application.Profit > 0)
            {
                lProfit.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}
