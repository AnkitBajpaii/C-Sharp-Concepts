using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethod
{
    public static class Util
    {
        public static bool IsNumeric(this string s)
        {
            float res;
            return float.TryParse(s, out res);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            string str1 = "1";
            string str2 = "abc";

            if (str1.IsNumeric())
                Console.WriteLine(str1 + " is numeric");
            else
                Console.WriteLine(str1 + " is not numeric");

            if (str1.IsNumeric())
                Console.WriteLine(str2 + " is numeric");
            else
                Console.WriteLine(str2 + " is not numeric");

            Console.ReadKey();
        }
    }
}
