using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCAAD.Contracts.Monitoring;
using log4net;


namespace SCAAD.APIs.Modules
{
    public class Log4NetLog<T> : ILog<T>
    {
        readonly ILog _log;

        public Log4NetLog()
        {
            _log = LogManager.GetLogger(typeof(T));
        }

        public void Debug(string message, params object[] formatArgs)
        {
            _log.DebugFormat(message, formatArgs);
        }

        public void Information(string message, params object[] formatArgs)
        {
            _log.InfoFormat(message, formatArgs);
        }

        public void Warning(string message, params object[] formatArgs)
        {
            _log.WarnFormat(message, formatArgs);
        }

        public void Error(string source, Exception exception)
        {
            _log.Error(source, exception);
        }

    }
}