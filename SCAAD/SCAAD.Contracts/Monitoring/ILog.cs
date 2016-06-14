using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.Contracts.Monitoring
{
    public interface ILog<T>
    {
        void Debug(string message, params object[] formatArgs);
        void Information(string message, params object[] formatArgs);
        void Warning(string message, params object[] formatArgs);
        void Error(string source, Exception exception);
    }
}
