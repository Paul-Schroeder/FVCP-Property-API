﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Business.Query
{
    public class GetPropertyByPinRequest : IRequest
    {
        public string Pin { get; set; }
    }
}
