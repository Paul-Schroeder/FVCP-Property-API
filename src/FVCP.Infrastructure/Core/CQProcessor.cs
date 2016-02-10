using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using FVCP.Business;

namespace FVCP.Infrastructure
{
    public class CQProcessor<T> : ICQProcessor<T>
    {
        readonly IWindsorContainer container;

        public CQProcessor(IWindsorContainer container)
        {
            this.container = container;
        }

        public ServiceResult<T> Process<TRequest>(TRequest request) where TRequest : IRequest
        {
            //var type = typeof(ICQExecution<,>).MakeGenericType(typeof(T), typeof(TRequest));
            //var command = container.Resolve(type);
            var cqProcessor = container.Resolve<ICQExecution<T, TRequest>>();
            ServiceResult<T> retVal = new ServiceResult<T>();

            try
            {
                retVal = cqProcessor.Execute(request);
            }
            finally
            {
                container.Release(cqProcessor);
            }

            return retVal;
        }
    }
}