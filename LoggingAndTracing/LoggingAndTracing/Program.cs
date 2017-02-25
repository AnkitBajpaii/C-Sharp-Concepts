using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EdgeVervePractice;

namespace LoggingAndTracing
{
    class Program
    {
        private static void CustomLoggingDemo()
        {
            string logPath = "D:\\Logs";

            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            do
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());

                try
                {
                    int c = a / b;
                    Console.WriteLine(c);
                }
                catch (DivideByZeroException e)
                {
                    //logging using custom logger
                    Logger.Log(e, "file", logPath);

                    //logging via tracing, setting done in app.config
                    Logger.Log(e, "Trace", logPath);
                }

                finally
                {
                    if (Directory.Exists(logPath) && File.Exists(logPath + "\\Log.txt"))
                    {
                        using (FileStream fs = new FileStream(logPath + "\\Log.txt", FileMode.Open, FileAccess.Read))
                        {
                            StreamReader sr = new StreamReader(fs);
                            string line = null;

                            while ((line = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }

                            sr.Close();
                        }
                    }
                }

            } while (true);
        }

        private static void TracingDemo()
        {
            string sProdName = "Widget";
            int iUnitQty = 100;
            double dUnitCost = 1.03;

            //Debug.WriteLine("Debug Information-Product Starting ");
            //Debug.Indent();
            //Debug.WriteLine("The product name is " + sProdName);
            //Debug.WriteLine("The available units on hand are" + iUnitQty.ToString());
            //Debug.WriteLine("The per unit cost is " + dUnitCost.ToString());

            Debug.WriteLine("The product name is " + sProdName, "Field");
            Debug.WriteLine("The units on hand are " + iUnitQty, "Field");
            Debug.WriteLine("The per unit cost is " + dUnitCost.ToString(), "Field");
            Debug.WriteLine("Total Cost is  " + (iUnitQty * dUnitCost), "Calc");

            Debug.WriteLineIf(iUnitQty > 50, "Units of hand greater than 50.","Conditional");

            Debug.Assert(dUnitCost > 1, "The per unit cost is very small");

            TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(tr1);

            TextWriterTraceListener tr2 = new TextWriterTraceListener(System.IO.File.CreateText("Output.txt"));
            Debug.Listeners.Add(tr2);

        }

        static void Main(string[] args)
        {
            CustomLoggingDemo();

            //TracingDemo();

            Console.ReadKey();
        }
    }
}