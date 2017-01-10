using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Statistics;
using NLog;


namespace Client_Application
{
    public enum Signal { Buy, Sell, Hold };

    class TradingStrategy
    {
        private List<Double> bidMAWithoutTrend;
        private List<Double> askMAWithoutTrend;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Signal Test()
        {
            return Signal.Buy;
        }

        public Signal BollingerBand(List<Double> bid,List<Double> ask)
        {
            Double upperLimit = bid.Mean() + (2 * bid.StandardDeviation());
            Double lowerLimit = ask.Mean() + (2 * ask.StandardDeviation());
            if(ask[ask.Count-1] < lowerLimit) { return Signal.Buy; }
            else if(bid[bid.Count - 1] > upperLimit) { return Signal.Sell; }
            return Signal.Hold;
        }
        
        public Signal SimpleMovingAverage(List<Double> bidTemp, List<Double> askTemp, int period)
        {
            List<Double> bid = new List<Double>(bidTemp);
            List<Double> ask = new List<Double>(askTemp);
            int count = bid.Count;
            if (count >= period)
            {
                var bidLast200 = bid.Skip(count - period).Take(period);
                var askLast200 = ask.Skip(count - period).Take(period);
                if(((askLast200.Skip(1).Take(period - 2).Mean() - askLast200.Take(period - 2).Mean()) < 0) && ((askLast200.Skip(2).Take(period - 2).Mean() - askLast200.Skip(1).Take(period - 2).Mean()) > 0))
                {
                    return Signal.Buy;
                }else if(((bidLast200.Skip(1).Take(period - 2).Mean() - bidLast200.Take(period - 2).Mean()) > 0) && ((bidLast200.Skip(2).Take(period - 2).Mean() - bidLast200.Skip(1).Take(period - 2).Mean()) < 0))
                {
                    return Signal.Sell;
                }

            }
            return Signal.Hold;
        }

        public Signal MCAD(List<Double> bid, List<Double> ask)
        {
            return Signal.Hold;
        }

        public Signal Decomposition(List<Double> bidTemp, List<Double> askTemp, int period = 990)
        {
            try
            {
                List<Double> bid = bidTemp.GetRange(period + bidMAWithoutTrend.Count, period);
                List<Double> ask = askTemp.GetRange(period + bidMAWithoutTrend.Count, period);
                if (bid.Count == period)
                {
                    double bidMA = bid.Mean();
                    double askMA = ask.Mean();
                    bidMAWithoutTrend.Add(bid[bid.Count - 1] / bidMA);
                    askMAWithoutTrend.Add(ask[ask.Count - 1] / askMA);

                }
            }
            catch (Exception e)
            {
                logger.Warn("Maybe a message has been skipped");
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace)
            }  
            return Signal.Hold;
        }

    }
}
