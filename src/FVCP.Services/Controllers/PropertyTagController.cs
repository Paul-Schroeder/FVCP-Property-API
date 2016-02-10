﻿using FVCP.Business.Query;
using FVCP.DTO;
using FVCP.Infrastructure;
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
        public PropertyTagDTO Get(int id)
        {
            PropertyTagDTO retVal = null;

            if (id > 0)
            {
                var cqProcessor = base.DIContainer.Resolve<ICQProcessor<IPropertyTagDTO>>();

                var srResult = cqProcessor.Process(new GetPropertyTagByIdRequest() { Id = id });

                if (srResult.Success)
                    retVal = srResult.Data as PropertyTagDTO;
            }

            return retVal;
        }


    }
}
