using System;
using System.Threading;

namespace MultithreadingDemo02
{
    public delegate void SumOfNumbersCallBack(int sumOfNumbers);

    class Number
    {
        int target;
        public Number(int target)
        {
            this.target = target;
        }

        public void PrintNumbers()
        {
            Console.WriteLine("PrintNumbers started");
            for (int i = 0; i <= target; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("PrintNumbers ended");
        }
    }

    class SumOfNum
    {
        int target;
        SumOfNumbersCallBack _callBackMethod;

        public SumOfNum(int target, SumOfNumbersCallBack callBack)
        {
            this.target = target;
            _callBackMethod = callBack;
        }

        public void SumOfNumbers()
        {
            int sum = 0;
            Console.WriteLine("SumOfNumbers started");
            for (int i = 1; i <= target; i++)
            {
                sum += i;
            }
            Console.WriteLine("SumOfNumbers ended");

            _callBackMethod(sum);
        }
    }

    class Program
    {
        #region ThreadingBasic
        static void DoWork()
        {
            Console.WriteLine("Inside t1 thread and Going to sleep for 5 seconds");
            
            Thread.Sleep(5000);
            Console.WriteLine("t1 thread awake and completed");
        }

        static void DoOtherWork()
        {
            Console.WriteLine("Inside t2 thread and Going to sleep for 3 seconds");
            Thread.Sleep(3000);
            Console.WriteLine("t2 thread awake and completed");
        }

        static void ThreadingBasic()
        {
            Console.WriteLine("Main thread started");
            Thread t1 = new Thread(DoWork);
            Console.WriteLine("Created instance of thread 1 and starting thread");
            t1.Start();

            Console.WriteLine("Created instance of thread 2 and starting thread");
            Thread t2 = new Thread(DoOtherWork);
            t2.Start();

            t2.Join();
            t1.Join();
            Console.WriteLine("Main thread completed");
        }

        #endregion

        #region ThreadStartDemo
        static void PrintNumbers()
        {
            Console.WriteLine("PrintNumbers started");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("PrintNumbers ended");
        }

        static void ThreadStartDemo()
        {
            Console.WriteLine("In Main thread..");
            Console.WriteLine("Creating child thread..");
            Thread t1 = new Thread(new ThreadStart(PrintNumbers));
            Console.WriteLine("Staring child thread..");
            t1.Start();
            Console.WriteLine("Main thread completed");
        }

        #endregion

        #region ParametrizedThreadStartDemo

        static void PrintNumbersByTarget(object target)
        {
            Console.WriteLine("PrintNumbers started");
            for (int i = 0; i <= Convert.ToInt32(target); i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("PrintNumbers ended");
        }

        static void ParametrizedThreadStartDemo()
        {
            Console.WriteLine("Main thread started");
            Console.WriteLine("Enter how times you want to execute loop");
            object target = Console.ReadLine();

            Console.WriteLine("Creating child thread..");
            Thread t1 = new Thread(new ParameterizedThreadStart(PrintNumbersByTarget));// Equivalent to-- Thread t1 = new Thread(PrintNumbersByTarget);
            Console.WriteLine("Staring child thread..");
            t1.Start(target);
            Console.WriteLine("Main thread completed");
        }

        #endregion

        #region TypeSafe safe manner of ParametrizedThreadStartDemo

        static void TypeSafeParametrizedThreadStartDemo()
        {
            Console.WriteLine("Main thread started");
            Console.WriteLine("Enter how times you want to execute loop");
            int target = Convert.ToInt32(Console.ReadLine());

            Number _num = new Number(target);
            Console.WriteLine("Creating child thread..");
            Thread t1 = new Thread(new ThreadStart(_num.PrintNumbers));// Equivalent to-- Thread t1 = new Thread(_num.PrintNumbers);
            Console.WriteLine("Staring child thread..");
            t1.Start();
            Console.WriteLine("Main thread completed");
        }

        #endregion

        #region Retrieving Data from Thread fucntion using CallBack method

        /// <summary>
        /// 1. Main thread receive target number from user
        /// 2.  Main thread creates child thread and pass the target number to the child thread
        /// 3. Child thread computes the sum of numbers and then returns the sum to the main thread using call back
        /// 4. Call back print the sum of the numbers
        /// </summary>
        static void RetreiveDataFromThreadFunctionUsingCallBack()
        {
            Console.WriteLine("Main thread started");

            Console.WriteLine("Enter the number upto which you want the sum");
            int target = Convert.ToInt32(Console.ReadLine());

            //step 1: create a callback delegate. The actual callback method signature should match with the signature of this delegate
            SumOfNumbersCallBack _callBack = new SumOfNumbersCallBack(PrintSumOfNumbers);

            SumOfNum _obj = new SumOfNum(target, _callBack);
            Console.WriteLine("Creating child thread..");
            Thread t1 = new Thread(new ThreadStart(_obj.SumOfNumbers));// Equivalent to-- Thread t1 = new Thread(_num.PrintNumbers);
            Console.WriteLine("Staring child thread..");
            t1.Start();
            Console.WriteLine("Main thread completed");
        }

        static void PrintSumOfNumbers(int sum)
        {
            Console.WriteLine("Sum is :", sum);
        }

        #endregion

        #region Significance of Thread.Join and Thread.IsAlive

        static void Thread1Function()
        {
            Console.WriteLine("Thread1Function started");
            Thread.Sleep(5000);
            Console.WriteLine("Thread1Function is about to return now");
        }

        static void Thread2Function()
        {
            Console.WriteLine("Thread2Function started");
        }

        static void SignificanceOf_ThreadJoin_And_ThreadIsAlive()
        {
            Console.WriteLine("Main Started");

            Thread t1 = new Thread(Thread1Function);
            t1.Start();

            Thread t2 = new Thread(Thread2Function);
            t2.Start();

            //t1.Join();//blocks current thread untill thread t1 is completeds
            if(t1.Join(1000)) //blocks current thread for 1 one second and checks if thread t1 is completed
            {
                Console.WriteLine("Thread1Function completed");
            }
            else
            {
                Console.WriteLine("Thread1Function is not completed in 1 second and still executing in its thread");
            }
            
            t2.Join();
            Console.WriteLine("Thread2Function completed");

            for (int i = 1; i <=10; i++)
            {
                if (t1.IsAlive)
                {
                    Console.WriteLine("Thread1Function is still doing its work");
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Thread1Function completed");
                }
            }
            
            Console.WriteLine("Main Completed");
        }
        #endregion

        static void Main(string[] args)
        {
            //ThreadingBasic();

            //ThreadStartDemo();

            //ParametrizedThreadStartDemo(); // Not type safe

            //TypeSafeParametrizedThreadStartDemo(); //now this is TypeSafe

            //RetreiveDataFromThreadFunctionUsingCallBack();

            //SignificanceOf_ThreadJoin_And_ThreadIsAlive();
            Console.ReadKey();

        }
    }
}

