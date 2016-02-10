using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static FVCP.Infrastructure.Core.Enums;

namespace FVCP.Infrastructure.Logging
{
    public class Log4NetLoggingService : ILoggingService //, log4net.ILog
    {
        //private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILog _log = null; // Let's lazy-load this to save processing in case it gets dependency injected and not used.

        public Log4NetLoggingService()
        {
            //[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
            // The following is not necessary - we use assembly declarations in AssemblyInfo.cs instead
            // Note, however, that the assembly attribute for XmlConfigurator must be present on the project where the "ILoggingService" implementation resides (i.e. "Infrastructure").
            // Otherwise, it will not log to the DB.
            //XmlElement log4NetSection = (XmlElement)ConfigurationManager.GetSection("log4net"); 
            //log4net.Config.XmlConfigurator.Configure(log4NetSection);
        }

        protected ILog CurrentLogger
        {
            get
            {
                if (_log == null)
                {
                    _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                }

                return _log;
            }
        }

        public void Debug()
        {
            throw new NotImplementedException();
        }

        public Guid Debug(string message, LogMessageType logMessageType, Exception ex, string userName = null, string clientIPAddress = null,
        [CallerMemberName] string methodName = null, [CallerFilePath] string sourceFile = null, [CallerLineNumber] int lineNumber = 0)
        {
            var logGuid = System.Guid.NewGuid();
            WriteDebugDiagnostics(message, logMessageType, ex, userName, clientIPAddress, methodName, sourceFile, lineNumber, logGuid);
            ILog log = SetCustomContextProperties(logMessageType, userName, clientIPAddress, methodName, logGuid);

            if (log.IsDebugEnabled)
            {
                if (ex != null)
                {
                    log.Debug(message, ex);
                }
                else
                {
                    log.Debug(message);
                }
            }

            return logGuid;
        }

        public Guid Error(string message, LogMessageType logMessageType, Exception ex, string userName = null, string clientIPAddress = null,
            [CallerMemberName] string methodName = null, [CallerFilePath] string sourceFile = null, [CallerLineNumber] int lineNumber = 0)
        {
            var logGuid = System.Guid.NewGuid();
            WriteDebugDiagnostics(message, logMessageType, ex, userName, clientIPAddress, methodName, sourceFile, lineNumber, logGuid);
            ILog log = SetCustomContextProperties(logMessageType, userName, clientIPAddress, methodName, logGuid);

            if (log.IsErrorEnabled)
            {
                if (ex != null)
                {
                    log.Error(message, ex);
                }
                else
                {
                    log.Error(message);
                }
            }

            return logGuid;
        }

        public Guid Fatal(string message, LogMessageType logMessageType, Exception ex, string userName = null, string clientIPAddress = null,
            [CallerMemberName] string methodName = null, [CallerFilePath] string sourceFile = null, [CallerLineNumber] int lineNumber = 0)
        {
            var logGuid = System.Guid.NewGuid();
            WriteDebugDiagnostics(message, logMessageType, ex, userName, clientIPAddress, methodName, sourceFile, lineNumber, logGuid);
            ILog log = SetCustomContextProperties(logMessageType, userName, clientIPAddress, methodName, logGuid);

            if (log.IsFatalEnabled)
            {
                if (ex != null)
                {
                    log.Fatal(message, ex);
                }
                else
                {
                    log.Fatal(message);
                }
            }

            return logGuid;
        }

        public Guid Info(string message, LogMessageType logMessageType, Exception ex, string userName = null, string clientIPAddress = null,
            [CallerMemberName] string methodName = null, [CallerFilePath] string sourceFile = null, [CallerLineNumber] int lineNumber = 0)
        {
            var logGuid = System.Guid.NewGuid();
            WriteDebugDiagnostics(message, logMessageType, ex, userName, clientIPAddress, methodName, sourceFile, lineNumber, logGuid);
            ILog log = SetCustomContextProperties(logMessageType, userName, clientIPAddress, methodName, logGuid);

            if (log.IsInfoEnabled)
            {
                if (ex != null)
                {
                    log.Info(message, ex);
                }
                else
                {
                    log.Info(message);
                }
            }

            return logGuid;
        }

        public Guid Warn(string message, LogMessageType logMessageType, Exception ex, string userName = null, string clientIPAddress = null,
            [CallerMemberName] string methodName = null, [CallerFilePath] string sourceFile = null, [CallerLineNumber] int lineNumber = 0)
        {
            var logGuid = System.Guid.NewGuid();
            WriteDebugDiagnostics(message, logMessageType, ex, userName, clientIPAddress, methodName, sourceFile, lineNumber, logGuid);
            ILog log = SetCustomContextProperties(logMessageType, userName, clientIPAddress, methodName, logGuid);

            if (log.IsWarnEnabled)
            {
                if (ex != null)
                {
                    log.Warn(message, ex);
                }
                else
                {
                    log.Warn(message);
                }
            }

            return logGuid;
        }

        [Conditional("DEBUG")]
        private void WriteDebugDiagnostics(string message, LogMessageType logMessageType, Exception ex, string userName, string clientIPAddress,
            string methodName, string sourceFile, int lineNumber, Guid logGuid)
        {
            //Desired string format: {"logMessageTypeID":0,"userName":"","message":"Successful login for admin.","exception":"","methodName":"Login","sourceFile":"c:\\TFS","lineNumber": 48, "logGuid" : "A5B5A056-E942-415A-84F9-8ADD64AB126A"}
            var msg = string.Format(@"{{""logMessageType"": ""{0}"",""userName"": ""{1}"",""clientIPAddress"": ""{2}"",""message"": ""{3}"",""exception"": ""{4}"",""methodName"": ""{5}"",""sourceFile"": ""{6}"",""lineNumber"": {7}, ""logGuid"": ""{8}""}}",
                Enum.GetName(typeof(LogMessageType), logMessageType), userName ?? string.Empty, clientIPAddress ?? string.Empty, message ?? string.Empty, GetExceptionString(ex), methodName ?? string.Empty, EscapeForJSON(sourceFile), lineNumber, logGuid);
            System.Diagnostics.Debug.WriteLine(msg);
        }

        private ILog SetCustomContextProperties(LogMessageType logMessageType, string userName, string clientIPAddress, string methodName, Guid logGuid)
        {
            ILog retVal = this.CurrentLogger;

            log4net.LogicalThreadContext.Properties["LogMessageTypeID"] = (int)logMessageType;
            log4net.LogicalThreadContext.Properties["MethodName"] = methodName;
            log4net.LogicalThreadContext.Properties["UserName"] = userName ?? string.Empty;
            log4net.LogicalThreadContext.Properties["ClientIPAddress"] = clientIPAddress ?? string.Empty;
            log4net.LogicalThreadContext.Properties["LogGuid"] = logGuid;

            return retVal;
        }

        private string GetExceptionString(Exception ex)
        {
            string retVal = string.Empty;

            if (ex != null)
            {
                retVal = string.Format("Exception type = {0}, message = {1}.", ex.GetType().ToString(), ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    retVal += string.Format("  Inner type = {0}, message = {1}.", ex.GetType().ToString(), ex.Message);
                }
            }

            return EscapeForJSON(retVal);
        }

        private string EscapeForJSON(string valueToEscape)
        {
            string retVal = string.Empty;

            if (!string.IsNullOrEmpty(valueToEscape))
            {
                retVal = valueToEscape.Replace(@"\", @"\\").Replace("\"", "\"\""); // Escape any solidus and/or quotation marks.
            }

            return retVal;
        }
    }
}
