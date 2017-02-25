using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DestructorsDemo
{
    class Base
    {
        public Base()
        {
            Console.WriteLine("Base  object created");
        }
        ~Base()
        {
            Console.WriteLine("Base destructor");
        }
    }

    class Derived : Base
    {
        public Derived()
        {
            Console.WriteLine("Derived  object created");
        }

        public Derived(string info)
        {

        }

        ~Derived()
        {
            Console.WriteLine("Derived destructor");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Base B1 = new Base();
            Base B2 = new Derived();

            Derived D1 = new Derived();
            Derived D2 = new Derived("ankit");

            Console.ReadKey();
        }
    }
}
