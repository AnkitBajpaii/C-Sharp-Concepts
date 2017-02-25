using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;

namespace LambdaExpDemo1
{
    class Program
    {
        public delegate int MyDelegate1(int i);

        public delegate bool MyDelegate2(int i, string s);

        static int Add(int i)
        {
            return 8 + i;
        }

        static void Main(string[] args)
        {
            int arg = 5;

            MyDelegate1 del = new MyDelegate1(x => x * x);
            Console.WriteLine("Calling MyDelegate1(x => x * x) with arg {0}: {1}", arg, del(arg));

            del = x => 3 * x;
            Console.WriteLine("Calling MyDelegate1(x => 3 * x) with arg {0}: {1}", arg, del(arg));

            del = new MyDelegate1(Add);//del=Add;
            Console.WriteLine("Calling MyDelegate1(Add) with arg {0}: {1}", arg, del(arg));

            MyDelegate2 myDel2 = (int x, string s) => s.Length > x;
            Console.WriteLine("Calling MyDelegate2((int x, string s) => s.Length > x) with arg (3, Ankit): {0}", myDel2(3, "Ankit"));
            Console.WriteLine(myDel2(3, "Ankit"));

            del = delegate (int i) { return i * i * i; };
            Console.WriteLine(del(5));

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int countEvenNum = numbers.Count(x => x % 2 == 0);

            int a = numbers.FirstOrDefault(x => x % 2 == 0);

            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            int j = 0;
            foreach (var item in firstNumbersLessThan6)
            {
                if (j == 0)
                    Console.Write(item);
                else
                    Console.Write("," + item);
                j++;
            }
            Console.WriteLine("\n");
            Action<int> _action = x => Console.WriteLine("Square of {0} is {1}", x, x * x);
            _action(4);

            List<int> Lst = new List<int>();
            Lst.Add(100);
            Lst.Add(200);
            Lst.Add(300);

            Func<int, bool> func = x => x > 100;

            int val = Lst.Find(x => x > 100);
            var res = Lst.FindAll(x => x > 100);

            Console.WriteLine(val);

            bool val1 = func(200);// func.Invoke(200);

            Console.ReadKey();
        }
    }
}
