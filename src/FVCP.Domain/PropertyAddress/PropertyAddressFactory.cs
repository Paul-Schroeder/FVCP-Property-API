using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public class PropertyAddressFactory
    {
        public virtual IPropertyAddress Create(IPropertyAddressDTO dto)
        {
            return new PropertyAddress(dto);
        }
    }
}
