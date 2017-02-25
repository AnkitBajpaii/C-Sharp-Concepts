using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonDemo
{
    class Singleton
    {
        private int _num;
        private static readonly Singleton _instance;

        internal static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }

        public int Num
        {
            get
            {
                return _num;
            }

            set
            {
                _num = value;
            }
        }

        static Singleton()
        {
            _instance = new Singleton();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s = Singleton.Instance;

            s.Num = 10;
            Singleton s1 = Singleton.Instance;
            Console.WriteLine(s1.Num);
        }
    }
}
