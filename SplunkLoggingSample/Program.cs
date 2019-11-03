using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplunkLoggingSample
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Initialize the LogWriter
            Logger.SetLogWriter(new LogWriterFactory().Create());

            //Prepare the LogEntry Object
            LogEntry entry = new LogEntry
            {
                Message = "Log Started with Enterprise Library and Udp Trace Listener.",
                EventId = 101,
                Severity = TraceEventType.Critical,
                Priority = 2,
                Title = "Udp TraceListener Logging"
            };

            //Can add additional info as key-value pair
            entry.ExtendedProperties.Add("Employee Number", 12345);

            //Log via Trace Listener
            //Logger.Write(entry);

            //Log via SLAB
            SLABLogging.LogMessage("Logging through SLAB", 1, 1, "SLAB Logging");

            Console.ReadKey();
        }
    }
}
