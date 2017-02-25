using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileStream fs = new FileStream("Test\\TestFile.txt", FileMode.Open, FileAccess.Read);
                Console.WriteLine("Reading " + fs.Name);

                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                fs = new FileStream("Test\\TestFile.txt", FileMode.Append, FileAccess.Write);
                Console.WriteLine("Writing " + fs.Name);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Adding new line.");
                }

                fs = new FileStream("Test\\TestFile.txt", FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: " + e.GetType().ToString() + " : " + e.Message.ToString());
            }

            Console.ReadKey();

        }
    }
}
