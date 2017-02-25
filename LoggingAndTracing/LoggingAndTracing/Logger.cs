using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EdgeVervePractice
{
    public static class Logger
    {
        public static void Log(Exception exp, string logType, string filePath = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("**************************************************************************************").Append(Environment.NewLine);
            sb.Append("Logging Started at:").Append(Environment.NewLine);
            sb.Append(DateTime.Now.ToString()).Append(Environment.NewLine);
            do
            {
                sb.Append("Exception Type:").Append(Environment.NewLine);
                sb.Append(exp.GetType().Name).Append(Environment.NewLine).Append(Environment.NewLine);

                sb.Append("Message:").Append(Environment.NewLine);
                sb.Append(exp.Message).Append(Environment.NewLine).Append(Environment.NewLine);

                sb.Append("Stack Trace:").Append(Environment.NewLine);
                sb.Append(exp.StackTrace).Append(Environment.NewLine).Append(Environment.NewLine);

                exp = exp.InnerException;
            } while (exp != null && exp.InnerException != null);

            if (logType.Equals("file"))
            {
                if (filePath != null)
                    LogToFile(sb.ToString(), filePath);
            }
            else if (logType.Equals("Trace"))
                TraceError(sb.ToString());
        }

        public static void LogToFile(string message, string path)
        {
            using (FileStream fs = new FileStream(path + "\\Log.txt", FileMode.Append, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(Environment.NewLine + message);
                sw.Close();
            }

        }

        public static void TraceError(string message)
        {
            Trace.WriteLine(message, "Trace Error");
        }
    }
}
