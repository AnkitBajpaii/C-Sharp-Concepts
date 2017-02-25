using System;

//Event in C#, the publisher Subscriber model
namespace EventsDemo1
{
    public class Publisher
    {
        public delegate void TickHandler(object sender, EventArgs e);
        // public event EventHandler TickEvent;
        public event TickHandler TickEvent;
        public EventArgs e = EventArgs.Empty;
        public void Start()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(3000);
                RaiseTickEvent();
            }
        }

        public void RaiseTickEvent()
        {
            if (TickEvent != null)
                TickEvent.Invoke(this, e);
        }
    }

    public class Subscriber
    {
        public Subscriber(Publisher p)
        {
            p.TickEvent += TickEventHandler;// new Publisher.TickHandler(TickEventHandler);
        }

        private void TickEventHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Event Raised.");
        }

        public void UnSubscribeEvent(Publisher p)
        {
            p.TickEvent -= TickEventHandler;// new Publisher.TickHandler(TickEventHandler);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Publisher p = new Publisher();
            Subscriber s = new Subscriber(p);

            p.Start();
        }
    }
}
