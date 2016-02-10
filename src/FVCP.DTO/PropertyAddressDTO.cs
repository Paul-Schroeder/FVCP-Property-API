using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.DTO
{
    [Serializable]
    public class PropertyAddressDTO : IPropertyAddressDTO
    {
        public string Pin { get; set; }
        public string HouseNum { get; set; }
        public string StreetDir { get; set; }
        public string Street { get; set; }
        public string Suffix { get; set; }
        public string Apt { get; set; }
        public string City { get; set; }
        public Nullable<short> Zip { get; set; }
    }
}
