using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaggedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray =
                                {
                                    new int[] {1,3,5,7,9},
                                    new int[] {0,2,4,6},
                                    new int[] {11,22}
                                };



            int elementCnt = jaggedArray.GetLength(0);
            Console.WriteLine("Jagged Array:\n");
            for (int i = 0; i < elementCnt; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (j == 0)
                        Console.Write("{" + jaggedArray[i][j]);
                    else
                        Console.Write("," + jaggedArray[i][j]);
                }
                Console.WriteLine("}");
            }
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();


        }
    }
}
