using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            ListWithChangedEvent list = new ListWithChangedEvent();
            EventListener listner = new EventListener(list);
            list.Add("item 1");
            list.Add("item 2");

            list.Clear();
            listner.Detach();
            
            Console.ReadKey();
        }
    }
}
