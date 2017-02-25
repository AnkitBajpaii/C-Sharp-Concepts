using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfacesDemo
{
    interface I1
    {

        void Display();
    }

    interface I2 : I1
    {
        void Show();
    }

    interface I3 : I2
    {
        void Print();
    }

    class BC : I1
    {
        public void Display()
        {
            Console.WriteLine("BC: Display()");
        }

        public void localBC()
        {
            Console.WriteLine("BC: localBC()");
        }
    }

    class DC : I2
    {
        public void Display()
        {
            Console.WriteLine("DC: Display()");
        }

        public void Show()
        {
            Console.WriteLine("DC: Show()");
        }

        public void localDC()
        {
            Console.WriteLine("DC: localDC()");
        }
    }

    class TC : I3
    {
        public void Display()
        {
            Console.WriteLine("TC: Display()");
        }

        public void Print()
        {
            Console.WriteLine("TC: Print()");
        }

        public void Show()
        {
            Console.WriteLine("TC: Show()");
        }

        public void localTC()
        {
            Console.WriteLine("TC: localTC()");
        }
    }

    abstract class A
    {
        public abstract void F1();
    }

    abstract class B
    {
        public abstract void F2();
    }

    class C : A //, B this will give error
    {
        public override void F1()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            I1 i1 = new BC();
            i1.Display();
            (i1 as BC).localBC();

            i1 = new DC();
            i1.Display();
            (i1 as I2).Show();
            (i1 as DC).localDC();

            i1 = new TC();
            i1.Display();
            (i1 as I2).Show();
        }
    }
}
