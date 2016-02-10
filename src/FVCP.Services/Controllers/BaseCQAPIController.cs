using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FVCP.Services.Controllers
{
    public class BaseCQAPIController : System.Web.Http.ApiController
    {
        Castle.Windsor.IWindsorContainer _container;
        public BaseCQAPIController(Castle.Windsor.IWindsorContainer container)
        {
            _container = container;
        }

        protected Castle.Windsor.IWindsorContainer DIContainer { get { return _container; } }

    }
}