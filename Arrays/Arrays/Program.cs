using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrays
{
    class Program
    {
        public delegate int MyDelegate(int i);
        public static void ChangeNum(int[,] multDimArr, MyDelegate del)
        {
            int rowCnt = multDimArr.GetLength(0);
            int colCnt = multDimArr.GetLength(1);
            for (int i = 0; i < rowCnt; i++)
            {
                for (int j = 0; j < colCnt; j++)
                {
                    multDimArr[i, j] = del(multDimArr[i, j]);
                }
            }
        }

        public static void Display2DArrayDetails(int[,] multDimArr)
        {
            int rowCnt = multDimArr.GetLength(0);
            int colCnt = multDimArr.GetLength(1);
            Console.WriteLine("{");
            for (int i = 0; i < rowCnt; i++)
            {
                for (int j = 0; j < colCnt; j++)
                {
                    if (j == 0)
                        Console.Write("{" + multDimArr[i, j]);
                    else
                        Console.Write("," + multDimArr[i, j]);
                }

                if (i == rowCnt - 1)
                    Console.WriteLine("}");
                else
                    Console.WriteLine("},");
            }
            Console.WriteLine("}");
        }

        public static void Display3DArrayDetails(int[,,] multDimArr)
        {
            int mainRow = multDimArr.GetLength(0);
            int row = multDimArr.GetLength(1);
            int col = multDimArr.GetLength(2);
            Console.WriteLine("{");
            for (int i = 0; i < mainRow; i++)
            {
                Console.WriteLine("{");

                for (int j = 0; j < row; j++)
                {
                    for (int k = 0; k < col; k++)
                    {
                        if (k == 0)
                            Console.Write("{" + multDimArr[i, j, k]);
                        else
                            Console.Write("," + multDimArr[i, j, k]);
                    }
                    if (j == row - 1)
                        Console.WriteLine("}");
                    else
                        Console.WriteLine("},");
                }
                if (i == mainRow - 1)
                    Console.WriteLine("}");
                else
                    Console.WriteLine("},");
            }
            Console.WriteLine("}");

        }

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
            int[,] multDimArr = new int[2, 3]{
                {1,2,3},
                {4,5,6}

            };

            int rowCnt = multDimArr.GetLength(0);
            int colCnt = multDimArr.GetLength(1);

            Console.WriteLine("Original 2D Array of {0} x {1}:", rowCnt, colCnt);
            Display2DArrayDetails(multDimArr);
            Console.WriteLine();

            Console.WriteLine("Squaring each element in 2D array:");
            ChangeNum(multDimArr, Square);
            Display2DArrayDetails(multDimArr);
            Console.WriteLine();

            int[,,] array3D = new int[2, 3, 2]{
                {
                    {1,2},
                    {3,4},
                    {5,6}
                },
                {
                    {7,8},
                    {9,10},
                    {11,12}
                }
            };
            int mainRow = array3D.GetLength(0);
            rowCnt = array3D.GetLength(1);
            colCnt = array3D.GetLength(2);

            Console.WriteLine("Original 3D Array of {0} x {1} x {2}:", mainRow, rowCnt, colCnt);

            Display3DArrayDetails(array3D);
            Console.ReadKey();


        }
    }
}
