using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Biblimania.Listeners
{
    class AppLogger
    {
        private String _filePath;
        public enum TypeError
        {
            Error,
            Warning,
            Info,
            Success
        }

        public AppLogger(String path)
        {
            _filePath = path;
            Trace.Listeners.Add(new TextWriterTraceListener(_filePath, "TraceListener"));
        }

        // Write a line in the log file with few informations
        public void Write(TypeError type, String message)
        {
            try
            {
               Trace.TraceInformation("[{0}][{1}] {2}", DateTime.Now, type, message);
               Trace.Flush();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // A StackTrace or a Source can be set here in addition
        public void Write(TypeError type, String message, String trace)
        {
            try
            {
                Trace.TraceInformation("[{0}][{1}] {2} - {3}", DateTime.Now, type, message, trace);
                Trace.Flush();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
