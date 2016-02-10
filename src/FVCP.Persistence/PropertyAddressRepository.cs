using FVCP.Domain;
using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Persistence
{
    public class PropertyAddressRepository : IPropertyAddressRepository
    {
        public static IPropertyAddressDTO MapFieldValues(EF.PropertyAddress dbItem)
        {
            if (dbItem == null)
                return null;

            IPropertyAddressDTO dto = new PropertyAddressDTO()
            {
                Apt = dbItem.Apt,
                City = dbItem.City,
                HouseNum = dbItem.HouseNum,
                Pin = dbItem.Pin,
                Street = dbItem.Street,
                StreetDir = dbItem.StreetDir,
                Suffix = dbItem.Suffix,
                Zip = dbItem.Zip
            };

            return dto;
        }

    }
}
