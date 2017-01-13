using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Statistics;
using NLog;


namespace Client_Application
{
    public enum Signal { Buy = 1, Sell = -1, Hold = 0 };
    public enum CurrentTrend {Bullish = 1, Bearish = -1, None =0 };

    class TradingStrategy
    {
        #region Variable
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region Decomposition Variables
        private List<Double> bidMAWithoutTrend = new List<double>();
        private List<Double> askMAWithoutTrend = new List<double>();
        private List<Double> maxBidVals = new List<double>();
        private List<Double> minAskVals = new List<double>();
        private int lastMaxBidValueLoc = -1;
        private int lastMinAskValueLoc = -1;
        private int megaCount = 0;
        #endregion

        private List<Double> macdLine = new List<double>();
        private List<Double> signalLine = new List<double>();
        private CurrentTrend trendCurrent = CurrentTrend.None;
        private CurrentTrend trendBolingerBand = CurrentTrend.None;
        private int countBolinger = 0;

        #endregion


        #region Strategies
        public Signal Test()
        {
            return Signal.Buy;
        }

        public Signal BollingerBand(List<Double> bidTemp,List<Double> askTemp, int period = 20)
        {
            if (bidTemp.Count >= period)
            {
                List<Double> bid = bidTemp.GetRange(bidTemp.Count - period, period);
                List<Double> ask = askTemp.GetRange(askTemp.Count - period, period);
                Double upperLimit = bid.Mean() + (2 * bid.StandardDeviation());
                Double lowerLimit = ask.Mean() - (2 * ask.StandardDeviation());
                if (ask[ask.Count - 1] <= lowerLimit && (trendBolingerBand != CurrentTrend.Bullish || countBolinger >=period)) {
                    countBolinger = -1;
                    trendBolingerBand = CurrentTrend.Bullish;
                    return Signal.Buy; }
                else if (bid[bid.Count - 1] >= upperLimit && (trendBolingerBand != CurrentTrend.Bearish || countBolinger>=period)) {
                    countBolinger = -1;
                    trendBolingerBand = CurrentTrend.Bearish;
                    return Signal.Sell; }
                countBolinger++;
            }
            return Signal.Hold;
        }
        
        public Signal SimpleMovingAverage(List<Double> bidTemp, List<Double> askTemp, int period)
        {
            try
            {
                List<Double> bid = new List<Double>(bidTemp);
                List<Double> ask = new List<Double>(askTemp);
                int count = bid.Count;
                if (count >= period)
                {
                    var bidLast200 = bid.Skip(count - period).Take(period);
                    var askLast200 = ask.Skip(count - period).Take(period);
                    if (((askLast200.Skip(1).Take(period - 2).Mean() - askLast200.Take(period - 2).Mean()) < 0) && ((askLast200.Skip(2).Take(period - 2).Mean() - askLast200.Skip(1).Take(period - 2).Mean()) > 0))
                    {
                        return Signal.Sell;
                    }
                    else if (((bidLast200.Skip(1).Take(period - 2).Mean() - bidLast200.Take(period - 2).Mean()) > 0) && ((bidLast200.Skip(2).Take(period - 2).Mean() - bidLast200.Skip(1).Take(period - 2).Mean()) < 0))
                    {
                        return Signal.Buy;
                    }

                }
            }
            catch (Exception e)
            {
                logger.Warn("Maybe a message has been skipped");
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }

            return Signal.Hold;
        }

        public Signal MACD(List<Double> askTemp, int longPeriod = 26, int midPeriod = 12,int shortPeriod = 9)
        {
            try
            {
                if (askTemp.Count >= longPeriod)
                {
                    List<Double> ask = askTemp.GetRange(askTemp.Count - longPeriod, longPeriod);
                    macdLine.Add(exponentialMovingAverage(ask.GetRange(ask.Count-midPeriod,midPeriod)) - exponentialMovingAverage(ask));
                    if (macdLine.Count >= shortPeriod) { signalLine.Add(exponentialMovingAverage(macdLine)); }
                    if (macdLine.Count > shortPeriod)
                    {
                        if ((macdLine[macdLine.Count - 1] >= signalLine[signalLine.Count - 1]) && (macdLine[macdLine.Count - 1] < signalLine[signalLine.Count - 1]))
                        {
                            return Signal.Sell;
                        }
                        else if ((macdLine[macdLine.Count - 1] < signalLine[signalLine.Count - 1]) && (macdLine[macdLine.Count - 1] >= signalLine[signalLine.Count - 1]))
                        {
                            return Signal.Buy;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn("Maybe a message has been skipped");
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return Signal.Hold;
        }

        public Signal Decomposition(List<Double> bidTemp, List<Double> askTemp, int period = 990)
        {
            try
            {
                int count = bidTemp.Count;
                if (count >= period)
                {
                    List<Double> bid = bidTemp.GetRange(megaCount, period);
                    List<Double> ask = askTemp.GetRange(megaCount++, period);
                    double bidMA = exponentialMovingAverage(bid);
                    double askMA = exponentialMovingAverage(ask);
                    bidMAWithoutTrend.Add(bid[bid.Count - 1] / bidMA);
                    askMAWithoutTrend.Add(ask[ask.Count - 1] / askMA);
                    if(bidMAWithoutTrend.Count % period == 0)
                    { 
                        double temp = bidMAWithoutTrend.Max();
                        maxBidVals.Add(bidMAWithoutTrend.IndexOf(temp));
                        temp = askMAWithoutTrend.Min();
                        minAskVals.Add(askMAWithoutTrend.IndexOf(temp));
                        bidMAWithoutTrend.Clear();
                        askMAWithoutTrend.Clear();
                        lastMaxBidValueLoc = ((count/period)*period) + (int)maxBidVals.Mean();
                        lastMinAskValueLoc = ((count/period)*period) + (int)minAskVals.Mean();
                    }
                    if(lastMaxBidValueLoc >0 && lastMinAskValueLoc > 0 && count > period)
                    {
                        if(count == lastMaxBidValueLoc + period) { return Signal.Sell; }
                        else if(count == lastMinAskValueLoc + period) { return Signal.Buy; }
                    }

                }
            }
            catch (Exception e)
            {
                logger.Warn("Maybe a message has been skipped");
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }  
            return Signal.Hold;
        }

        public Signal TwoMovingAverage(List<Double> bidTemp, List<Double> askTemp, int periodShort = 60, int periodLong = 200)
        {
            try
            {
                if (bidTemp.Count > periodLong)
                {
                    List<Double> bid = bidTemp.GetRange(bidTemp.Count - periodLong - 1, periodLong + 1);
                    List<Double> ask = bidTemp.GetRange(askTemp.Count - periodLong - 1, periodLong + 1);
                    if ((ask.GetRange(0,periodLong).Mean() >= ask.GetRange(0,periodShort).Mean()) && (ask.GetRange(1, periodLong).Mean() < ask.GetRange(1, periodShort).Mean()))
                    { return Signal.Buy; }
                    else if ((bid.GetRange(0, periodLong).Mean() < bid.GetRange(0, periodShort).Mean()) && (bid.GetRange(1, periodLong).Mean() >= bid.GetRange(1, periodShort).Mean()))
                    { return Signal.Sell; }
                }

            }
            catch (Exception e)
            {
                logger.Warn("Maybe a message has been skipped");
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return Signal.Hold;
        }

        #endregion


        #region Other Functions
        private double exponentialMovingAverage(List<Double> data, double weight = -1)
        {
            if(weight == -1) { weight = (2.0 /Convert.ToDouble (1 + data.Count)); }
            double result = 0;
            int power = data.Count - 1;
            foreach (double value in data)
            {
                result += Math.Pow((1 - weight), power--) * weight * value;
            }
            return result;
        }

        #endregion

    }
}
