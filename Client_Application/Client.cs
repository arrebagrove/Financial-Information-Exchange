﻿using System;
using System.Collections.Generic;
using QuickFix;
using QuickFix.Fields;
using MathNet.Numerics.Statistics;
using NLog;

namespace Client_Application
{
    class Client : IApplication
    {
        #region Variables

        private Session session = null;
        private bool marketDataGet;
        private long quoteMessageCount = 0;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private Dictionary<string, string> marketData = new Dictionary<string, string>();
        public List<QuickFix.FIX44.ExecutionReport> trades = new List<QuickFix.FIX44.ExecutionReport>();
        private ExcelInsert excel = new ExcelInsert();
        private List<Double> bidPrices = new List<Double>();
        private List<Double> askPrices = new List<Double>();
        private TradingStrategy strategy = new TradingStrategy();
        private Dictionary<int,Double> buyingPrices = new Dictionary<int, double>();
        private Dictionary<int, Double> sellingPrices = new Dictionary<int, double>();
        private Decimal profit = 0m;
        private Decimal portfolioValue = 0m;
        private const Decimal brokerage = 0.005m;
        private long totalOrders = 0;
        private string data;
        private long totalQuantityPortfolio = 0;

        #endregion

        #region Constructors &  Setter Getter
        public bool MarketDataGet
        {
            get
            {
                return marketDataGet;
            }

            set
            {
                marketDataGet = value;
            }
        }

        public decimal Profit
        {
            get
            {
                return profit;
            }
        }

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public List<double> AskPrices
        {
            get
            {
                return askPrices;
            }

        }

        public long TotalQuantityPortfolio
        {
            get
            {
                return totalQuantityPortfolio;
            }
        }

        public Dictionary<int, double> BuyingPrices
        {
            get
            {
                return buyingPrices;
            }

        }

        public Dictionary<int, double> SellingPrices
        {
            get
            {
                return sellingPrices;
            }
        }

        public Client(bool dataGet)
        {
            MarketDataGet = dataGet;
        }
        #endregion

        #region Interface Implementation
        public void FromApp(Message message, SessionID sessionID)
        {
            if (message is QuickFix.FIX44.ExecutionReport)
            {
                data = "Execution Report : " + message.ToString();
                trades.Add((QuickFix.FIX44.ExecutionReport)message);
                calculateProfit((QuickFix.FIX44.ExecutionReport)message);
                logger.Info("Execution Report: " + message.ToString());

            }
            else if (message is QuickFix.FIX44.Quote)
            {
                data = "Quote: " + message.ToString();
                quoteMessageCount++;
                QuoteMessageCracker(message.ToString());
                logger.Info("Quote: " + message.ToString());
                if (!marketDataGet)
                {
                    TradeAutomatically();
                }
            }
            else
            {
                data = message.ToString();
            }
            viewProfit();

        }

        public void ToApp(Message message, SessionID sessionId)
        {

        }

        public void OnCreate(SessionID sessionID)
        {
            session = Session.LookupSession(sessionID);
        }

        public void OnLogon(SessionID sessionID)
        {
            data = "\nLogon - " + sessionID.ToString();
        }

        public void OnLogout(SessionID sessionID)
        {
            data = "\nLogout - " + sessionID.ToString();
        }

        public void ToAdmin(Message message, SessionID sessionID)
        {
            data = "\nMessage to Admin: " + message.ToString();
        }

        public void FromAdmin(Message message, SessionID sessionID)
        {
            data = "\nMessage from Admin: " + message.ToString();
        }

        #endregion

        #region Functions used by Client

        private void QuoteMessageCracker(string message)
        {
            string[] tempMessage = message.Split(message[9]);
            long temp;
            foreach (string section in tempMessage)
            {
                string[] keyValue = section.Split('=');
                if (Int64.TryParse(keyValue[0], out temp))
                {
                    switch (temp)
                    {
                        case 34:
                            marketData["MessageSequenceNUmber"] = keyValue[1];
                            break;
                        case 52:
                            marketData["TimeStamp"] = keyValue[1];
                            break;
                        case 117:
                            marketData["Symbol"] = keyValue[1];
                            break;
                        case 132:
                            marketData["BidPrice"] = keyValue[1];
                            break;
                        case 133:
                            marketData["AskPrice"] = keyValue[1];
                            break;
                        default:
                            break;
                    }
                }
            }
            bidPrices.Add(Double.Parse(marketData["BidPrice"]));
            askPrices.Add(Double.Parse(marketData["AskPrice"]));
            excel.insertIntoExcelFile(marketData, quoteMessageCount);
        }

        public void StartExcel(string file)
        {
            excel.OpenExcelSheet(file);
        }

        public void CloseExcel()
        {
            excel.CloseExcelSheet();
        }

        public void TradeAutomatically()
        {
            try
            {
                int multiplyingFactor = 1000;
                //Signal signal1 = strategy.BollingerBand(bidTemp: bidPrices, askTemp: askPrices);

                //Signal signal2 = strategy.SimpleMovingAverage(bidTemp: bidPrices, askTemp: askPrices, period: 60);
                Signal signal3 = strategy.Decomposition(bidTemp: bidPrices, askTemp: askPrices);
                //Signal signal4 = strategy.TwoMovingAverage(bidPrices,askPrices);
                //Signal signal5 = strategy.MACD(askTemp: askPrices);
                //long quantity = (long)(((int)signal1 + 0.25*(int)signal2 + 4*(int)signal3 + 0.5*(int)signal4 + 2*(int)signal5)*multiplyingFactor);
                long quantity = (int)signal3 * multiplyingFactor;
                totalQuantityPortfolio += quantity;
                if (quantity > 0) { sendOrderRequest(createOrder(quantity, new Side(Side.BUY))); }
                else if (quantity < 0) { sendOrderRequest(createOrder(-1*quantity, new Side(Side.SELL))); }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }

            return;
        }

        public QuickFix.FIX44.NewOrderSingle createOrder(long orderQty, Side side, string symbol = "MFM")
        {
            QuickFix.FIX44.NewOrderSingle order = new QuickFix.FIX44.NewOrderSingle();
            order.ClOrdID = new ClOrdID(symbol + DateTime.Now.TimeOfDay);
            order.TransactTime = new TransactTime(DateTime.Now, true);
            order.Symbol = new Symbol(symbol);
            order.OrderQty = new OrderQty(orderQty);
            order.OrdType = new OrdType(OrdType.MARKET);
            order.Side = side;
            return order;
        }

        public void sendOrderRequest(QuickFix.FIX44.NewOrderSingle order)
        {
            logger.Info("Order Details: " + order.ToString());
            Session.SendToTarget(order, session.SessionID);
        }

        public void calculateProfit(QuickFix.FIX44.ExecutionReport order)
        {
            if(order.Side.getValue() == '1') { buyingPrices.Add(askPrices.Count, (double)order.Price.getValue()); }
            else if(order.Side.getValue() == '2') { sellingPrices.Add(askPrices.Count, (double)order.Price.getValue()); }
            if (order.Side.getValue() == '1')
            {
                portfolioValue -= (order.Price.getValue() + brokerage)* order.CumQty.getValue();
                totalOrders += (long)order.CumQty.getValue();
            }
            else if (order.Side.getValue() == '2')
            {
                portfolioValue += (order.Price.getValue() - brokerage)* order.CumQty.getValue();
                totalOrders -= (long)order.CumQty.getValue();
            }
            if (totalOrders < 0)
            {
                profit = portfolioValue + (Convert.ToDecimal(askPrices[askPrices.Count-1]) + brokerage) * totalOrders; 
            }else if (totalOrders > 0)
            {
                profit = portfolioValue + (Convert.ToDecimal(bidPrices[bidPrices.Count-1]) - brokerage) * totalOrders;
            }
        }

        public void viewProfit()
        {
            if (totalOrders < 0)
            {
                profit = portfolioValue + (Convert.ToDecimal(askPrices[askPrices.Count-1]) + brokerage) * totalOrders;
            }
            else if (totalOrders > 0)
            {
                profit = portfolioValue + (Convert.ToDecimal(bidPrices[bidPrices.Count-1]) - brokerage) * totalOrders;
            }
        }

        public List<Double> getMovingAverage(int period)
        {
            List<Double> temp = new List<double>(askPrices);
            List<Double> price = new List<double>();
            foreach(Double val in temp.MovingAverage(period))
            {
                price.Add(val);
            }
            return price;
        }

        #endregion

    }
}
