using Castle.Core.Logging;
using Castle.DynamicProxy;
using Newtonsoft.Json;
using System;
using System.Text;
using static FVCP.Infrastructure.Core.Enums;

namespace FVCP.Infrastructure.Logging
{
    public class ExceptionLogger : IInterceptor //, IExceptionLogger
    {
        //ILogger log;
        ILoggingService _log;

        public ExceptionLogger(ILoggingService log) //(ILogger log)
        {
            this._log = log;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine(string.Format("Before method: {0}", invocation.Method.Name));
                foreach (var argumentItem in invocation.Arguments)
                {
                    _log.Info(String.Concat("Argument: ", JsonConvert.SerializeObject(argumentItem))
                        , LogMessageType.Unknown);
                }

                invocation.Proceed();
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("Method '{0}' of class '{1}' failed. ",
                                            invocation.Method.Name,
                                            invocation.TargetType.Name));

                foreach (var argumentItem in invocation.Arguments)
                {
                    sb.Append(String.Concat("Argument: ", JsonConvert.SerializeObject(argumentItem)));
                }

                _log.Error(sb.ToString(), LogMessageType.Exception_Unhandled, e);
                throw;
            }
        }
    }
}