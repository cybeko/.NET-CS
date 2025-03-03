using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Logger
    {
        static readonly string filePath = "log.txt";

        public void LogAdded(string firstName, string lastName)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string message = $"Added employee: {firstName} {lastName} at {time}";
            LogToFile(message);
        }

        public void LogDeleted(string firstName, string lastName)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string message = $"Deleted employee: {firstName} {lastName} at {time}";
            LogToFile(message);
        }

        public void LogSearched(string criteria, string input)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string message = $"Searched by {criteria}: {input} at {time}";
            LogToFile(message);
        }

        private void LogToFile(string message)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
