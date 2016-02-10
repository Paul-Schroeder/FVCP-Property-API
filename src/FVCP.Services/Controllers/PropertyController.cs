using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FVCP.Business;

using FVCP.Infrastructure;
using FVCP.Business.Command;
using Newtonsoft.Json;
using FVCP.Business.Query;
using FVCP.DTO;

namespace FVCP.Services.Controllers
{
    public class PropertyController : BaseCQAPIController
    {
        //IRequestProcessor _requestProcessor;

        public PropertyController(Castle.Windsor.IWindsorContainer container)
            : base(container)
        {
        }

        [ActionName("DefaultAction")]
        public string Get(string pin)
        {
            string retVal = null;

            if (!string.IsNullOrEmpty(pin))
            {
                var cqProcessor = base.DIContainer.Resolve<ICQProcessor<PropertyDTO>>();

                var srResult = cqProcessor.Process(new GetPropertyByPinRequest()
                {
                    Pin = pin
                });
            }

            return retVal;
        }

        [HttpGet]
        public void AddTag(string pin, string tag)
        {
            var request = new AddPropertyTagRequest()
            {
                Pin = pin,
                Tag = tag
            };

//            _requestProcessor.Process<AddPropertyTagRequest>(request);
        }

    }
}
