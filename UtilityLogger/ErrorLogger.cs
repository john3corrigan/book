using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UtilityLogger
{
    public class ErrorLogger
    {
        public void LogError(Exception _errorToWrite)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString(""));
            message += Environment.NewLine;
            message += "----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message {0}", _errorToWrite.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", _errorToWrite.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", _errorToWrite.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", _errorToWrite.TargetSite.ToString());
            message += Environment.NewLine;
            message += "----------------------------------------------------------";
            message += Environment.NewLine;

            using (StreamWriter _writer = new StreamWriter("C:\\Users\\Onshore\\Downloads\\BookLibrary\\BookLibrary\\UtilityLogger\\ErrorLog.txt", true))
            {
                _writer.WriteLine(message);
            }
        }
    }
}
