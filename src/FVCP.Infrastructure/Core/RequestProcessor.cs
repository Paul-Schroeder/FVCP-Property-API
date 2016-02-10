using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using FVCP.Business;

namespace FVCP.Infrastructure
{
    //public class RequestProcessor : IRequestProcessor
    //{
    //    readonly IWindsorContainer container;

    //    public RequestProcessor(IWindsorContainer container)
    //    {
    //        this.container = container;
    //    }

    //    public void Process<TRequest>(TRequest request) where TRequest : IRequest
    //    {
    //        var command = container.Resolve<ICommand<TRequest>>();

    //        try
    //        {
    //            command.Execute(request);
    //        }
    //        finally
    //        {
    //            container.Release(command);
    //        }
    //    }
    //}
}