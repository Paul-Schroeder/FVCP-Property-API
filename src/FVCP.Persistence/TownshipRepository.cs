﻿using FVCP.Domain;
using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Persistence
{
    public class TownshipRepository : ITownshipRepository
    {
        public static ITownshipDTO MapFieldValues(EF.Township dbItem)
        {
            if (dbItem == null)
                return null;

            ITownshipDTO retVal = new TownshipDTO()
            {
                TownNum = dbItem.TownNum,
                Name = dbItem.Name
            };

            return retVal;
        }

    }
}
