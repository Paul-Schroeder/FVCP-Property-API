using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public class PropertyTag : IPropertyTag
    {
        public PropertyTag(IPropertyTagDTO data)
        {
            this.Data = data;
        }

        public IPropertyTagDTO Data { get; set; }
    }
}
