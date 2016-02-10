using FVCP.Business.Command;
using FVCP.Business.Query;
using FVCP.DTO;
using FVCP.Infrastructure;
using FVCP.Services.Infrastructure;
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
            if (id <= 0)
                return BadRequest("Id must be greater than zero.");

            IHttpActionResult retVal = null;
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

            return retVal;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] string data)
        {
            data = WebUtility.UrlDecode(data);
            if (string.IsNullOrEmpty(data))
                return BadRequest("Empty request detected.");

            IHttpActionResult retVal = null;
            PropertyTagDTO dto = JsonConvert.DeserializeObject<PropertyTagDTO>(data);
            var cqProcessor = base.DIContainer.Resolve<ICQProcessor<PropertyTagDTO>>();
            var srResult = cqProcessor.Process(new AddPropertyTagRequest() { Pin = dto.Pin, Name = dto.Name });
            if (srResult.Success)
            {
                retVal = Created<PropertyTagDTO>(Request.RequestUri + srResult.Data.Id.ToString(), srResult.Data);
            }
            else
            {
                switch (srResult.ErrorID)
                {
                    case "404":
                        retVal = NotFound();
                        break;
                    case "422":
                        // Conflict = 409, really should be 422 - Unprocessable Entity 
                        // the server understands the content type of the request entity (hence a 415 Unsupported Media Type status code is inappropriate), 
                        // and the syntax of the request entity is correct (thus a 400 Bad Request status code is inappropriate) but was unable to process the contained instructions.
                        retVal = new ErrorResult(Request, HttpStatusCode.Conflict, srResult.Message);
                        break;
                    default:
                        retVal = InternalServerError(new ApplicationException(srResult.Message));
                        break;
                }
            }

            return retVal;
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] string data)
        {
            data = WebUtility.UrlDecode(data);
            if (string.IsNullOrEmpty(data))
                return BadRequest("Empty request detected.");

            IHttpActionResult retVal = null;
            PropertyTagDTO dto = JsonConvert.DeserializeObject<PropertyTagDTO>(data);
            var cqProcessor = base.DIContainer.Resolve<ICQProcessor<PropertyTagDTO>>();
            var srResult = cqProcessor.Process(new UpdatePropertyTagRequest() { Id = dto.Id, Name = dto.Name });
            if (srResult.Success)
            {
                retVal = Ok<PropertyTagDTO>(srResult.Data);
            }
            else
            {
                switch (srResult.ErrorID)
                {
                    case "404":
                        retVal = NotFound();
                        break;
                    default:
                        retVal = InternalServerError(new ApplicationException(srResult.Message));
                        break;
                }
            }

            return retVal;
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody] string data)
        {
            data = WebUtility.UrlDecode(data);
            if (string.IsNullOrEmpty(data))
                return BadRequest("Empty request detected.");

            IHttpActionResult retVal = null;
            PropertyTagDTO dto = JsonConvert.DeserializeObject<PropertyTagDTO>(data);
            var cqProcessor = base.DIContainer.Resolve<ICQProcessor<bool>>();
            var srResult = cqProcessor.Process(new DeletePropertyTagRequest() { Id = dto.Id });
            if (srResult.Success)
            {
                retVal = Ok(string.Format("Id '{0}' successfully deleted.", dto.Id));
            }
            else
            {
                switch (srResult.ErrorID)
                {
                    case "404":
                        retVal = NotFound();
                        break;
                    default:
                        retVal = InternalServerError(new ApplicationException(srResult.Message));
                        break;
                }
            }

            return retVal;
        }


    }
}
