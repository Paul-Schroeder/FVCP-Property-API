﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Business.Command
{
    public class AddPropertyTagRequest : IRequest
    {
        public string Pin { get; set; }
        public string Name { get; set; }
    }
}
