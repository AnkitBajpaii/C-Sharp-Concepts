#define DEBUG
using System;
using System.Diagnostics;

namespace Attributes
{
    public class Myclass
    {
        [Conditional("DEBUG")]
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }

        [Obsolete("Don't use OldMethod, use NewMethod instead", true)]
        public static void oldMethod()
        {
            Console.WriteLine("It is the old method");
        }
    }

    class Program
    {
        static void function1()
        {
            Myclass.Message("In Function 1.");
            function2();
        }
        static void function2()
        {
            Myclass.Message("In Function 2.");
        }

        static void Main(string[] args)
        {

            Myclass.Message("In Main function.");
            function1();
            //Myclass.oldMethod();
            Console.ReadKey();
        }
    }


}
