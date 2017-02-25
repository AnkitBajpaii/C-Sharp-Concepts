using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsDemo2
{
    public class ListWithChangedEventArgs: EventArgs
    {
        private int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private object _item;

        public object Item
        {
            get { return _item; }
            set { _item = value; }
        }
        
    }
}
