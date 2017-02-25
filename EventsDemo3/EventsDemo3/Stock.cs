using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsDemo3
{
    public class Stock
    {
        public Stock(string symbol)
        {
            this.Symbol = symbol;
        }

        string _symbol;

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        decimal _price;

        public decimal Price
        {
            get { return _price; }
            set 
            {
                if (_price == value)
                    return;
                RaisePriceChangedEvent(new PriceChangedEventArgs(_price, value));
                _price = value;
            }
        }

        public event EventHandler<PriceChangedEventArgs> PriceChangedEvent;
        public virtual void RaisePriceChangedEvent(PriceChangedEventArgs e)
        {
            if (PriceChangedEvent != null)
                PriceChangedEvent(this, e);
        }
    }
}
