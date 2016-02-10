using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.DTO
{
    public interface IPropertyAddressDTO
    {
        string Pin { get; set; }
        string HouseNum { get; set; }
        string StreetDir { get; set; }
        string Street { get; set; }
        string Suffix { get; set; }
        string Apt { get; set; }
        string City { get; set; }
        Nullable<short> Zip { get; set; }
    }
}
