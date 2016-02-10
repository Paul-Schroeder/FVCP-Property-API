using FVCP.Domain;
using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Persistence
{
    public class PropertyTagRepository
    {
        public static List<IPropertyTagDTO> MapFieldValues(ICollection<EF.PropertyTag> dbItems)
        {
            var myFact = new PropertyTagFactory();
            List<IPropertyTagDTO> retVal = new List<IPropertyTagDTO>();

            if (dbItems == null)
                return retVal;

            foreach (var dbItem in dbItems)
            {
                IPropertyTagDTO dto = new PropertyTagDTO()
                {
                    Id = dbItem.Id,
                    Name = dbItem.Name,
                    Pin = dbItem.Pin
                };

                retVal.Add(dto);
            }

            return retVal;
        }

    }
}
