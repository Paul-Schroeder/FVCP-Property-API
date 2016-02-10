using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public class PropertyFactory
    {
        public virtual IProperty Create(IPropertyDTO dto)
        {
            return new Property(dto);
        }
    }
}
