using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCompiler
{
    class Stock
    {
        
        public string Name { get; set; }
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public double AdjustedClose { get; set; }

        public Stock(string name, string symbol, DateTime date, double open, double high, double low, double close, double volume, double adjustedClose)
        {
            this.Name = name;
            this.Symbol = symbol;
            this.Date = date;
            this.Open = open;
            this.High = high;
            this.Low = low;
            this.Close = close;
            this.Volume = volume;
            this.AdjustedClose = adjustedClose;

        }
    }

}
