using FVCP.Business.Query;
using FVCP.DTO;
using FVCP.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FVCP.Services.Controllers
{
    public class PropertyTagController : BaseCQAPIController
    {
        public PropertyTagController(Castle.Windsor.IWindsorContainer container)
            : base(container)
        {

        }

        [ActionName("DefaultAction")]
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult retVal = null;

            if (id <= 0)
            {
                retVal = BadRequest("Id must be greater than zero.");
            }
            else
            {
                var cqProcessor = base.DIContainer.Resolve<ICQProcessor<PropertyTagDTO>>();
                var srResult = cqProcessor.Process(new GetPropertyTagByIdRequest() { Id = id });

                if (srResult.Success)
                {
                    retVal = Ok<PropertyTagDTO>(srResult.Data); //JsonConvert.SerializeObject(srResult.Data);
                }
                else
                {
                    retVal = NotFound();
                }
            }

            return retVal;
        }


    }
}
