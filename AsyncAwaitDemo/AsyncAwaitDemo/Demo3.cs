using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started Main method, Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            TestAsyncAwaitMethods();
            Console.WriteLine("Press any key to exit... " + "Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();
            Console.ReadKey();
        }

        public async static void TestAsyncAwaitMethods()
        {
            Console.WriteLine("Inside TestAsyncAwaitMethods , Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            //await LongRunningMethod();
            var task = LongRunningMethod();

            await task;

            Console.WriteLine("After LongRunningMethod , Thread Id: " + Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task<int> LongRunningMethod()
        {
            Console.WriteLine("Starting Long Running method... " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(5000);
            Console.WriteLine("End Long Running method... " + Thread.CurrentThread.ManagedThreadId);
            return 1;
        }

    }
}
