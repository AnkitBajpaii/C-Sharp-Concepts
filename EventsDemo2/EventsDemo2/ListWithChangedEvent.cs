using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EventsDemo2
{
    public class ListWithChangedEvent: ArrayList
    {
        public delegate void ChangedEventHandler(object sender, ListWithChangedEventArgs e);
        //public event EventHandler<ListWithChangedEventArgs> Changed;
        public event ChangedEventHandler Changed;

        public virtual void RaiseChangedEvent(ListWithChangedEventArgs e)
        {
            if (Changed != null)
                Changed.Invoke(this, e);
        }

        public override int Add(object value)
        {
            int i = base.Add(value);
            ListWithChangedEventArgs e = new ListWithChangedEventArgs();
            e.Index = i;
            e.Item = value;
            RaiseChangedEvent(e);
            return i;
        }

        public override void Clear()
        {
            base.Clear();
            ListWithChangedEventArgs e = new ListWithChangedEventArgs();
            e.Item = null;
            RaiseChangedEvent(e);
        }

        public override object this[int index]
        {
            set
            {
                base[index] = value;
                ListWithChangedEventArgs e = new ListWithChangedEventArgs();
                RaiseChangedEvent(e);
            }
        }

    }
}
