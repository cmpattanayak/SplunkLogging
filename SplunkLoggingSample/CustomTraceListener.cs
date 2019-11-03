using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Splunk.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplunkLoggingSample
{
    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public class CustomTraceListener : UdpTraceListener
    {
        string host;
        int port;

        public CustomTraceListener(string _host, int _port) :base(_host, _port)
        {
            this.host = _host;
            this.port = _port;
        }
    }
}
