using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FVCP.Infrastructure.Core.Enums;

namespace FVCP.Infrastructure.Logging
{
    public interface ILoggingService
    {
        //log4net.ILog CurrentLogger { get; }

        Guid Debug(string message, LogMessageType logMessageType, Exception ex = null, string userName = null, string clientIPAddress = null, string methodName = null, string sourceFile = null, int lineNumber = 0);
        Guid Error(string message, LogMessageType logMessageType, Exception ex = null, string userName = null, string clientIPAddress = null, string methodName = null, string sourceFile = null, int lineNumber = 0);
        Guid Fatal(string message, LogMessageType logMessageType, Exception ex = null, string userName = null, string clientIPAddress = null, string methodName = null, string sourceFile = null, int lineNumber = 0);
        Guid Info(string message, LogMessageType logMessageType, Exception ex = null, string userName = null, string clientIPAddress = null, string methodName = null, string sourceFile = null, int lineNumber = 0);
        Guid Warn(string message, LogMessageType logMessageType, Exception ex = null, string userName = null, string clientIPAddress = null, string methodName = null, string sourceFile = null, int lineNumber = 0);
    }
}
