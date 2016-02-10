using FVCP.Domain;
using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Persistence
{
    public class PropertyClassRepository : IPropertyClassRepository
    {
        public static PropertyClassDTO MapFieldValues(EF.PropertyClass dbItem)
        {
            if (dbItem == null)
                return null;

            PropertyClassDTO retVal = new PropertyClassDTO()
            {
                ClassNum = dbItem.ClassNum,
                Name = dbItem.Name
            };

            return retVal;
        }

    }
}
