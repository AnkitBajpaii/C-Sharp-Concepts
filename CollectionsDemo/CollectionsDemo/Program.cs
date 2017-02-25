using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace CollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // not type safe, boxing-unboxing, performance penalty
            ArrayList arrList = new ArrayList();

            arrList.Add(1);
            arrList.Add("Ankit");


            //below will give error
            //foreach (int item in arrList)
            //{
            //    Console.WriteLine(item);
            //}

            Hashtable hashTbl = new Hashtable();
            hashTbl.Add(1, "Ankit");
            hashTbl.Add(2, "Ankit");

            foreach (DictionaryEntry item in hashTbl)
            {
                Console.WriteLine(item.Key + "." + item.Value);
            }

            NameValueCollection nameValueCollec = new NameValueCollection();
            nameValueCollec.Add("A+", "Excellent");
            nameValueCollec.Add("A", "Very Good");
            nameValueCollec.Add("B+", "Good");
            nameValueCollec.Add(null, "Good");
            nameValueCollec.Add("B", "Ok");
            nameValueCollec.Add("B", null);
            nameValueCollec.Add("C", "Satisfactory");
            nameValueCollec.Add("C", "Satisfactory");

            string[] values = null;
            foreach (string keyStr in nameValueCollec.Keys)
            {
                values = nameValueCollec.GetValues(keyStr);
                foreach (string valStr in values)
                {
                    Console.WriteLine(keyStr + "-->" + valStr);
                }

            }


            SortedList<int, string> sortedList = new SortedList<int, string>();
            sortedList.Add(1, "ankit");
            sortedList.Add(3, "ram");
            sortedList.Add(2, "sumit");

            foreach (KeyValuePair<int, string> item in sortedList)
            {
                Console.WriteLine(item.Key + ", " + item.Value);
            }

            Dictionary<int, string> dict = new Dictionary<int, string>();


            Console.ReadKey();
        }
    }
}
