using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Splunk.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplunkLoggingSample
{
    public class SLABLogging
    {
        private static string host = ConfigurationManager.AppSettings["HostName"].ToString();
        private static int port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);

        public static void LogMessage(string message, int severity, int priority, string title)
        {
            var listener = new ObservableEventListener();
            listener.Subscribe(new UdpEventSink(host, port));

            var eventSource = new SimpleEventSource();
            listener.EnableEvents(eventSource, EventLevel.LogAlways, Keywords.All);

            eventSource.Message(message, severity, priority, title);
        }
    }

    [EventSource(Name = "SLABEventSource")]
    public class SimpleEventSource : EventSource
    {
        public class Keywords { }
        public class Tasks { }

        [Event(1, Message = "{0}", Level = EventLevel.Informational)]
        internal void Message(string Message, int Severity, int Priority, string Title)
        {
            this.WriteEvent(1, Message, Severity, Priority, Title);
        }
    }
}
