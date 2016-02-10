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
        public ServiceResult<IPropertyTag> AddPropertyTag(string pin, string name)
        {
            ServiceResult<IPropertyTag> retVal = new ServiceResult<IPropertyTag>();
            FVCP.Persistence.EF.PropertyTag dbItem = null;
            using (var db = new PropertyEntities())
            {
                dbItem = db.PropertyTags
                    .FirstOrDefault(x => x.Pin == pin && x.Name == name);

                if (dbItem == null)
                {   // Go ahead and add the item, it isn't a duplicate.
                    dbItem = new EF.PropertyTag()
                    {
                        Name = name,
                        Pin = pin
                    };

                    db.PropertyTags.Add(dbItem);
                    db.SaveChanges();  // ID value should populate.

                    PropertyTagDTO dto = PropertyTagRepository.MapFieldValues(dbItem);
                    PropertyTagFactory myFact = new PropertyTagFactory();
                    retVal.Data = myFact.Create(dto);
                    retVal.Success = true;
                }
                else
                {
                    retVal.Success = false;
                    retVal.ErrorID = "422";
                    retVal.Message = string.Format("Unprocessable Entity - Tag '{0}' already exists for PIN '{1}'", name, pin);
                }
            }

            return retVal;
        }


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


        public ServiceResult<IPropertyTag> UpdatePropertyTag(int id, string name)
        {
            ServiceResult<IPropertyTag> retVal = new ServiceResult<IPropertyTag>();
            FVCP.Persistence.EF.PropertyTag dbItem = null;
            using (var db = new PropertyEntities())
            {
                dbItem = db.PropertyTags
                    .FirstOrDefault(x => x.Id == id);

                if (dbItem != null)
                {
                    dbItem.Name = name;
                    db.SaveChanges();

                    PropertyTagFactory myFact = new PropertyTagFactory();
                    retVal.Data = myFact.Create(GetPropertyTagById(id).Data);
                    retVal.Success = true;
                }
                else
                {   // Item doesn't exist.
                    retVal.Success = false;
                    retVal.ErrorID = "404";
                    retVal.Message = string.Format("Tag id '{0}' was not found.  Unable to update property tag '{1}'.",
                        id, name);
                }
            }

            return retVal;
        }

        public ServiceResult<bool> DeletePropertyTag(int id)
        {
            ServiceResult<bool> retVal = new ServiceResult<bool>();
            FVCP.Persistence.EF.PropertyTag dbItem = null;
            using (var db = new PropertyEntities())
            {
                dbItem = db.PropertyTags
                    .FirstOrDefault(x => x.Id == id);

                if (dbItem != null)
                {
                    db.PropertyTags.Remove(dbItem);
                    db.SaveChanges();

                    retVal.Data = true;
                    retVal.Success = true;
                }
                else
                {   // Item doesn't exist.
                    retVal.Success = false;
                    retVal.ErrorID = "404";
                    retVal.Message = string.Format("Tag id '{0}' was not found.  Unable to delete property tag.",
                        id);
                }
            }

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
