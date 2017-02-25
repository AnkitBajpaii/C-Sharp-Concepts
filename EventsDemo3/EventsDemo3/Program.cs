using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsDemo3
{
  
   class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock("THPW");
            stock.Price = 27.10M;
            stock.PriceChangedEvent += stock_PriceChangedEvent;
            stock.Price = 50.10M;

            Console.ReadKey();
        }

        static void stock_PriceChangedEvent(object sender, PriceChangedEventArgs e)
        {
            if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
                Console.WriteLine("Alert, 10% stock price increase!");
        }
    }
}
