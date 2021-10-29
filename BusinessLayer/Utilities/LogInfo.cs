using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BusinessLayer.Utilities
{
    public class LogInfo : ILogInfo
    {
        // <summary>
        // Log class to Log execution messages to a text file
        // <summary>

        public void Log(string logMessage)
        {
            string fileName = @"C:\Users\Muhammad Talha\source\repos\StudentManageSystem\logs.txt";
            LogToFile(logMessage, fileName);
            
            
        }

        public void LogToFile(string logMessage, string fileName)
        {
            if (!File.Exists(fileName))
            {
                StreamWriter sw = File.CreateText(fileName);
            }
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        //Log messages at current time
                        sw.WriteLine(logMessage + $" at {DateTime.Now}");
                        //sw.Flush();
                        //sw.Close();
                        //fs.Close();
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Log File Not FOund");
            }
        }
    }
}
