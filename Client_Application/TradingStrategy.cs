using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;


namespace Client_Application
{
    public enum Signal { Buy, Sell, Hold };

    class TradingStrategy
    {
        public Signal BollingerBand(List<Double> bid,List<Double> ask)
        {
            Double upperLimit = bid.Mean() + (2 * bid.StandardDeviation());
            Double lowerLimit = ask.Mean() + (2 * ask.StandardDeviation());
            if(ask[ask.Count-1] < lowerLimit) { return Signal.Buy; }
            else if(bid[bid.Count - 1] > upperLimit) { return Signal.Sell; }
            return Signal.Hold;
        }
        
        public Signal SimpleMovingAverage(List<Double> bidTemp, List<Double> askTemp)
        {
            List<Double> bid = new List<Double>(bidTemp);
            List<Double> ask = new List<Double>(askTemp);
             int count = bid.Count;
            if (count >= 210)
            {
                var bidLast200 = bid.Skip(count - 210).Take(210);
                var askLast200 = ask.Skip(count - 210).Take(210);
                if(((askLast200.Skip(5).Take(200).Mean() - askLast200.Take(200).Mean()) < 0) && ((askLast200.Skip(10).Take(200).Mean() - askLast200.Skip(5).Take(200).Mean()) > 0))
                {
                    return Signal.Buy;
                }else if(((bidLast200.Skip(5).Take(200).Mean() - bidLast200.Take(200).Mean()) > 0) && ((bidLast200.Skip(10).Take(200).Mean() - bidLast200.Skip(5).Take(200).Mean()) < 0))
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

    }
}
