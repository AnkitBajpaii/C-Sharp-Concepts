using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        static async Task<int> HandleFileAsync()
        {
            string file = @"D:\enable.txt";
            Console.WriteLine("HandleFile enter: "+ Thread.CurrentThread.ManagedThreadId);
            int count = 0;

            // Read in the specified file.
            // ... Use async StreamReader method.
            using (StreamReader reader = new StreamReader(file))
            {
                Console.WriteLine("Before ReadToEndAsync: " + Thread.CurrentThread.ManagedThreadId);
                string v = await reader.ReadToEndAsync();
                Console.WriteLine("After ReadToEndAsync: " + Thread.CurrentThread.ManagedThreadId);
                // ... Process the file data somehow.
                count += v.Length;

                // ... A slow-running computation.
                //     Dummy code.
                Console.WriteLine("Running a costly operation: " + Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("Completed a costly operation & HandleFile exit: " + Thread.CurrentThread.ManagedThreadId);
            return count;
        }

        public static async Task MyMethodAsync()
        {
            Console.WriteLine("Inside MyMethodAsync and before LongRunningOperationAsync: " + Thread.CurrentThread.ManagedThreadId);
            Task<int> longRunningTask = LongRunningOperationAsync();
            Console.WriteLine("After LongRunningOperationAsync: " + Thread.CurrentThread.ManagedThreadId);
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here

            Console.WriteLine("Before await: " + Thread.CurrentThread.ManagedThreadId);
            //and now we call await on the task 
            int result = await longRunningTask;
            Console.WriteLine("After await: " + Thread.CurrentThread.ManagedThreadId);
            //use the result 
            Console.WriteLine(result);
        }

        public static async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
        {
            Console.WriteLine("Inside LongRunningOperationAsync: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(5000); 
            Console.WriteLine("Exiting LongRunningOperationAsync: " + Thread.CurrentThread.ManagedThreadId);
            return 1;
        }

        static void Main(string[] args)
        {
            //Example 1
            Console.WriteLine("Before MyMethodAsync: " + Thread.CurrentThread.ManagedThreadId);
            var t = MyMethodAsync();
            Console.WriteLine("After MyMethodAsync: " + Thread.CurrentThread.ManagedThreadId);

            //Example 2
            //Console.WriteLine("Main Started: " + Thread.CurrentThread.ManagedThreadId);
            //// Start the HandleFile method.
            //var task = HandleFileAsync();
            //Console.WriteLine("After HandleFileAsync: " + Thread.CurrentThread.ManagedThreadId);
            //// Control returns here before HandleFileAsync returns.           

            //// Do something at the same time as the file is being read.
            //string line = Console.ReadLine();
            //Console.WriteLine("You entered: " + line + " : " + Thread.CurrentThread.ManagedThreadId);

            //// Wait for the HandleFile task to complete.
            //// ... Display its results.
            //Console.WriteLine("Main thread waiting: " + Thread.CurrentThread.ManagedThreadId);
            //task.Wait();
            //Console.WriteLine("Main thread wait completed: " + Thread.CurrentThread.ManagedThreadId);
            //var x = task.Result;
            //Console.WriteLine("Count: " + x);

            Console.WriteLine("[DONE]");
            Console.ReadLine();
        }
    }
}
