using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public class PropertyTagFactory
    {
        public virtual IPropertyTag Create(IPropertyTagDTO dto)
        {
            return new PropertyTag(dto);
        }
    }
}
