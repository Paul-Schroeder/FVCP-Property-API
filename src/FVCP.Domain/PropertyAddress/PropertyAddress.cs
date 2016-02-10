using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public class PropertyAddress : PropertyAddressDTO, IPropertyAddress
    {
        public PropertyAddress(IPropertyAddressDTO data)
        {
            this.Data = data;
        }

        public IPropertyAddressDTO Data { get; set; }
    }
}
