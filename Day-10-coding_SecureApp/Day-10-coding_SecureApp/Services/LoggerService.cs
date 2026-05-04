using System;
using System.Collections.Generic;
using System.Text;

namespace Day_10_coding_SecureApp.Services
{
    public class LoggerService
    {
        private string path = "log.txt";

        public void Log(string message)
        {
            string log = $"{DateTime.Now} - {message}";
            File.AppendAllText(path, log + Environment.NewLine);
        }
    }

}
