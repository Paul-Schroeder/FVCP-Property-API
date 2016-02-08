using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FVCP.Business;

using FVCP.Infrastructure;
using FVCP.Business.Command;

namespace FVCP.Services.Controllers
{
    public class PropertyController : ApiController
    {
        IRequestProcessor _requestProcessor;

        public PropertyController(IRequestProcessor requestProcessor)
        {
            this._requestProcessor = requestProcessor;
        }

        [HttpGet]
        public void AddTag(string pin, string tag)
        {
            var request = new AddPropertyTagRequest()
            {
                Pin = pin,
                Tag = tag
            };

            _requestProcessor.Process<AddPropertyTagRequest>(request);
        }

    }
}
