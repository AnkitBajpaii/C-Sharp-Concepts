using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateUsingInterface
{
    interface IMyInterface
    {
        int ChangeNum(int i);
    }

    class MyClass
    {
        public static void MyClassChangeNum(int[] arr, IMyInterface myInterface)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = myInterface.ChangeNum(arr[i]);
            }
        }
    }

    class Square : IMyInterface
    {
        public int ChangeNum(int i)
        {
            return i * i;
        }
    }

    class Cube : IMyInterface
    {
        public int ChangeNum(int i)
        {
            return i * i * i;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            Console.WriteLine("Original Array:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("Squaring each element in array:");
            MyClass.MyClassChangeNum(arr, new Square());
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            var initialMemory = System.GC.GetTotalMemory(true);
            Console.WriteLine("Total memory usage after squaring: " + initialMemory);

            Console.WriteLine("Cubing each element in array:");
            MyClass.MyClassChangeNum(arr, new Cube());
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            var finalMemory = System.GC.GetTotalMemory(true);
            Console.WriteLine("Total memory usage after cubing: " + finalMemory);
            Console.ReadKey();
        }
    }
}
