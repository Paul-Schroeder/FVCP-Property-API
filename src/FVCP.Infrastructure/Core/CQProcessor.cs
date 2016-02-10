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
            var command = container.Resolve<ICQExecution<T, TRequest>>();
            ServiceResult<T> retVal = new ServiceResult<T>();

            try
            {
                retVal = command.Execute(request);
            }
            finally
            {
                container.Release(command);
            }

            return retVal;
        }
    }
}