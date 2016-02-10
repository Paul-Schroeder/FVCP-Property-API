using FVCP.Domain;
using FVCP.DTO;
using FVCP.Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Persistence
{
    public class PropertyTagRepository : IPropertyTagRepository
    {
        public IPropertyTag GetPropertyTagById(int id)
        {
            FVCP.Persistence.EF.PropertyTag dbItem = null;
            using (var db = new PropertyEntities())
            {
                dbItem = db.PropertyTags
                    .FirstOrDefault(x => x.Id == id);
            }

            PropertyTagDTO dto = PropertyTagRepository.MapFieldValues(dbItem);
            PropertyTagFactory myFact = new PropertyTagFactory();
            IPropertyTag retVal = myFact.Create(dto);

            return retVal;
        }

        public static PropertyTagDTO MapFieldValues(EF.PropertyTag dbItem)
        {
            if (dbItem == null)
                return null;

            PropertyTagDTO retVal = new PropertyTagDTO()
            {
                Id = dbItem.Id,
                Name = dbItem.Name,
                Pin = dbItem.Pin
            };

            return retVal;
        }

        public static List<PropertyTagDTO> MapFieldValues(ICollection<EF.PropertyTag> dbItems)
        {
            List<PropertyTagDTO> retVal = new List<PropertyTagDTO>();

            if (dbItems == null)
                return retVal;

            foreach (var dbItem in dbItems)
            {
                PropertyTagDTO dto = new PropertyTagDTO()
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
