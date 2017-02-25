using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsDemo2
{
    public class EventListener
    {
        private ListWithChangedEvent List;
        public EventListener(ListWithChangedEvent _list)
        {
            List = _list;
            //List.Changed += new ListWithChangedEvent.ChangedEventHandler(List_Changed);            
            List.Changed += List_Changed;
        }

        private void List_Changed(object sender, ListWithChangedEventArgs e)
        {
            if(e.Item != null)
                Console.WriteLine(e.Item+ " inserted into list at index "+e.Index);
            else
                Console.WriteLine("List is cleared");
        }
        
        public void Detach()
        {
            List.Changed -= new ListWithChangedEvent.ChangedEventHandler(List_Changed);
            List = null;
        }
    }
}
