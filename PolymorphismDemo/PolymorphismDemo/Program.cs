using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Mehtod overriding example
/// </summary>
namespace PolymorphismDemo
{
    class BC
    {
        public void Display()
        {
            Console.WriteLine("BC: Display()");
        }

        public virtual void Show()
        {
            Console.WriteLine("BC: Show()");
        }

        public virtual void Print()
        {
            Console.WriteLine("BC: Print()");
        }

        public virtual void Details()
        {
            Console.WriteLine("BC: Details()");
        }

        public virtual void JustWow()
        {
            Console.WriteLine("BC: JustWow()");
        }
    }

    class DC : BC
    {
        public new void Display()
        {
            Console.WriteLine("DC: Display()");
        }

        public new void Show()
        {
            Console.WriteLine("DC: Show()");
        }

        public override void Print()
        {
            Console.WriteLine("DC: Print()");
        }

        public override void Details()
        {
            Console.WriteLine("DC: Details()");
        }

        public virtual new void JustWow()
        {
            Console.WriteLine("DC: JustWow()");
        }
    }

    class TC : DC
    {
        public new void Display()
        {
            Console.WriteLine("TC: Display()");
        }

        //	'TC.Show()': cannot override inherited member 'DC.Show()' because it is not marked virtual, abstract, or override PolymorphismDemo C:\Users\ANKIT\Study\Self made Projects\EventsDemo1\PolymorphismDemo\Program.cs	41	Active
        //public override void Show()
        //{
        //    Console.WriteLine("DC: Show()");
        //}

        public new void Show()
        {
            Console.WriteLine("TC: Show()");
        }

        public new void Print()
        {
            Console.WriteLine("TC: Print()");
        }

        public override void Details()
        {
            Console.WriteLine("TC: Details()");
        }

        public override void JustWow()
        {
            Console.WriteLine("TC: JustWow()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BC bc = new BC();
            bc.Display();

            DC dc = new DC();
            dc.Display();

            TC tc = new TC();
            tc.Display();

            bc = dc;
            bc.Display();

            bc = tc;
            bc.Display();

            bc = new BC();
            bc.Show();

            bc = dc;
            bc.Show();

            bc = tc;
            bc.Show();

            bc = new BC();
            bc.Print();

            bc = dc;
            bc.Print();

            bc = tc;
            bc.Print();

            bc = new BC();
            bc.Details();

            bc = dc;
            bc.Details();

            bc = tc;
            bc.Details();

            bc = new BC();
            bc.JustWow();

            bc = dc;
            bc.JustWow();

            bc = tc;
            bc.JustWow();


            Console.ReadKey();
        }
    }
}
