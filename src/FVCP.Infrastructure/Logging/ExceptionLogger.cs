using Castle.Core.Logging;
using Castle.DynamicProxy;
using System;

namespace FVCP.Infrastructure.Logging
{
    public class ExceptionLogger : IInterceptor //, IExceptionLogger
    {
        ILogger log;

        public ExceptionLogger(ILogger log)
        {
            this.log = log;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Before method: {0}", invocation.Method.Name));
                invocation.Proceed();
                System.Diagnostics.Debug.WriteLine(string.Format("After method: {0}", invocation.Method.Name));
            }
            catch (Exception e)
            {
                var message = string.Format("Method '{0}' of class '{1}' failed.",
                                            invocation.Method.Name,
                                            invocation.TargetType.Name);
                log.Error(message, e);
                throw;
            }
        }
    }
}