using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using FVCP.Persistence.EF;
using FVCP.Domain;
using FVCP.DTO;

namespace FVCP.Persistence
{
    public class PropertyRepository : IPropertyRepository
    {
        public void AddTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IProperty GetByPin(string pin)
        {
            FVCP.Persistence.EF.Property dbProperty = null;
            using (var db = new PropertyEntities())
            {
                dbProperty = db.Properties
                    .Include(x => x.PropertyAddress)
                    .Include(x => x.PropertyClass)
                    .Include(x => x.PropertyTags)
                    .Include(x => x.Township)
                    .FirstOrDefault(x => x.Pin == pin);
            }

            PropertyDTO dto = PropertyRepository.MapFieldValues(dbProperty);
            PropertyFactory myFact = new PropertyFactory();
            IProperty retVal = myFact.Create(dto);

            return retVal;
        }

        public static PropertyDTO MapFieldValues(EF.Property dbItem)
        {
            if (dbItem == null)
                return null;

            var myFact = new PropertyFactory();
            PropertyDTO retVal = new PropertyDTO()
            {
                Age = dbItem.Age,
                AirCond = dbItem.AirCond,
                AptCount = dbItem.AptCount,
                AtticDesc = dbItem.AtticDesc,
                BasementDesc = dbItem.BasementDesc,
                BuildingSF = dbItem.BuildingSF,
                BuildingUse = dbItem.BuildingUse,
                ClassNum = dbItem.ClassNum,
                CommUnits = dbItem.CommUnits,
                ExtDesc = dbItem.ExtDesc,
                Fireplace = dbItem.Fireplace,
                FullBath = dbItem.FullBath,
                GarageDesc = dbItem.GarageDesc,
                HalfBath = dbItem.HalfBath,
                HomeImpYear = dbItem.HomeImpYear,
                LandSF = dbItem.LandSF,
                LocationId = dbItem.LocationId,
                NeighborhoodId = dbItem.NeighborhoodId,
                Pin = dbItem.Pin,
                PropertyAddressDTO = PropertyAddressRepository.MapFieldValues(dbItem.PropertyAddress),
                PropertyClassDTO = PropertyClassRepository.MapFieldValues(dbItem.PropertyClass),
                PropertyTagDTOs = PropertyTagRepository.MapFieldValues(dbItem.PropertyTags),
                ResType = dbItem.ResType,
                SaleAmount = dbItem.SaleAmount,
                SaleDate = dbItem.SaleDate,
                TaxCode = dbItem.TaxCode,
                TotalAllBuildingSF = dbItem.TotalAllBuildingSF,
                TownNum = dbItem.TownNum,
                TownshipDTO = TownshipRepository.MapFieldValues(dbItem.Township),
                UnitsTotal = dbItem.UnitsTotal,
                Volume = dbItem.Volume
            };

            return retVal;
        }

        public IProperty Save(IProperty property)
        {
            throw new NotImplementedException();
        }

    }
}
