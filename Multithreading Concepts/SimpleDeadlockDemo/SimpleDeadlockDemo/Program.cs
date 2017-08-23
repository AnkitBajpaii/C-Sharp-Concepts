using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SimpleDeadlockDemo
{
    class DeadLock
    {
        private static object _lockA = new object();
        private static object _lockB = new object();

        public static void CompleteWork1()
        {
            lock (_lockA)
            {
                Console.WriteLine("trying to acquire lock on _lockB");

                lock (_lockB)
                {
                    Console.WriteLine("Critical section for CompleteWork1");
                }
            }
        }

        public static void CompleteWork2()
        {
            lock (_lockB)
            {
                Console.WriteLine("trying to acquire lock on _lockA");

                lock (_lockA)
                {
                    Console.WriteLine("Critical section for CompleteWork2");
                }
            }
        }

        public static void ExecuteDeadLockCode()
        {
            Thread _thread1 = new Thread(CompleteWork1);
            Thread _thread2 = new Thread(CompleteWork2);
            _thread1.Start();
            _thread2.Start();

            _thread1.Join();
            _thread2.Join();

            Console.WriteLine("Processing completed...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DeadLock.ExecuteDeadLockCode();

            Console.WriteLine("\nPress any key to continue.");


            Console.ReadKey();
        }
    }
}
