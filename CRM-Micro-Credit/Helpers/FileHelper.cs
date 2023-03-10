using CRM_Micro_Credit.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Micro_Credit.Helpers
{
    public class FileHelper
    {
        private readonly string logPath;

        public FileHelper(string logPath)
        {
            this.logPath = logPath;
        }

        /// <summary>
        /// Запись в файл
        /// </summary>
        /// <param name="text"></param>
        public void WriteLog(string text)
        {
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine($"{DateTime.Now} | {text}");
            }
        }

        /// <summary>
        /// Запись в файл
        /// </summary>
        /// <param name="text"></param>
        /// <param name="methodName"></param>
        public void WriteLog(string text, string methodName)
        {
            using(StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine($"{DateTime.Now} | {text} in method {methodName}");
            }
        }
    }
}
