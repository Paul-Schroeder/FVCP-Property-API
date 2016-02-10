using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public class PropertyClassFactory
    {
        public virtual IPropertyClass Create(IPropertyClassDTO dto)
        {
            return new PropertyClass(dto);
        }
    }
}
