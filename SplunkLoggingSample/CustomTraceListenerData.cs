using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using System.Configuration;
using System.Diagnostics;

namespace SplunkLoggingSample
{
    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public class CustomTraceListenerData : TraceListenerData
    {
        private const string hostProperty = "host";
        private const string portProperty = "port";

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CustomTraceListenerData()
        {

        }

        [ConfigurationProperty(hostProperty, IsRequired = true)]
        public string HostName
        {
            get { return (string)base[hostProperty]; }
            set { base[hostProperty] = value; }
        }

        [ConfigurationProperty(portProperty, IsRequired = true)]
        public int PortNumber
        {
            get { return (int)base[portProperty]; }
            set { base[portProperty] = value; }
        }

        /// <summary>
        /// Initialize the Custom TraceListener with hostname and port
        /// </summary>
        /// <param name="settings"></param>
        /// <returns>Custome TraceListener</returns>
        protected override TraceListener CoreBuildTraceListener(LoggingSettings settings)
        {
            return new CustomTraceListener(HostName, PortNumber);
        }
    }
}
