using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateDemo1
{
    public delegate int MyDelegate(int i);

    class MyClass
    {
        public static void ChangeNum(int[] arr, MyDelegate del)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = del(arr[i]);
            }
        }
    }
    class Program
    {
        static int Square(int i)
        {
            return i * i;
        }

        static int Cube(int i)
        {
            return i * i * i;
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Original Array:");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + (i == arr.Length - 1 ? "" : " , "));
            }
            Console.WriteLine();
            Console.WriteLine("Squaring each element in array:");
            MyClass.ChangeNum(arr, Square);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            var initialMemory = System.GC.GetTotalMemory(true);
            Console.WriteLine("Total memory usage after squaring: " + initialMemory);

            Console.WriteLine("Cubing each element in array:");
            MyClass.ChangeNum(arr, Cube);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            var finalMemory = System.GC.GetTotalMemory(true);
            Console.WriteLine("Total memory usage after cubing: " + finalMemory);
            Console.ReadLine();

        }
    }
}
