using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public class PropertyClass : IPropertyClass
    {
        public PropertyClass(PropertyClassDTO data)
        {
            this.Data = data;
        }

        public PropertyClassDTO Data { get; set; }
    }
}
