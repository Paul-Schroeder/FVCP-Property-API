using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.DTO
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Note, automatic properties are not used here in order to removing backing fields from DTO's 
    /// for serialization purposes.  This avoids properties coming out with names like '...kBackingField'.
    /// </remarks>
    [Serializable]
    public class PropertyDTO
    {
        public PropertyDTO()
        {
            this.PropertyTagDTOs = new List<PropertyTagDTO>();
        }

        private string pin;

        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        private short classNum;

        public short ClassNum
        {
            get { return classNum; }
            set { classNum = value; }
        }

        private int townNum;

        public int TownNum
        {
            get { return townNum; }
            set { townNum = value; }
        }

        private short? volume;

        public short? Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        private string locationId;

        public string LocationId
        {
            get { return locationId; }
            set { locationId = value; }
        }

        private int taxCode;

        public int TaxCode
        {
            get { return taxCode; }
            set { taxCode = value; }
        }

        private int neighborhoodId;

        public int NeighborhoodId
        {
            get { return neighborhoodId; }
            set { neighborhoodId = value; }
        }

        private short? homeImpYear;

        public short? HomeImpYear
        {
            get { return homeImpYear; }
            set { homeImpYear = value; }
        }

        private string resType;

        public string ResType
        {
            get { return resType; }
            set { resType = value; }
        }

        private string buildingUse;

        public string BuildingUse
        {
            get { return buildingUse; }
            set { buildingUse = value; }
        }

        private string aptCount;

        public string AptCount
        {
            get { return aptCount; }
            set { aptCount = value; }
        }

        private string commUnits;

        public string CommUnits
        {
            get { return commUnits; }
            set { commUnits = value; }
        }

        private string  extDesc;

        public string ExtDesc
        {
            get { return extDesc; }
            set { extDesc = value; }
        }

        private byte? fullBath;

        public byte? FullBath
        {
            get { return fullBath; }
            set { fullBath = value; }
        }

        private byte? halfBath;

        public byte? HalfBath
        {
            get { return halfBath; }
            set { halfBath = value; }
        }

        private string basementDesc;

        public string BasementDesc
        {
            get { return basementDesc; }
            set { basementDesc = value; }
        }

        private string atticDesc;

        public string AtticDesc
        {
            get { return atticDesc; }
            set { atticDesc = value; }
        }

        private byte? airCond;

        public byte? AirCond
        {
            get { return airCond; }
            set { airCond = value; }
        }

        private byte? firePlace;

        public byte? Fireplace
        {
            get { return firePlace; }
            set { firePlace = value; }
        }

        private string garageDesc;

        public string GarageDesc
        {
            get { return garageDesc; }
            set { garageDesc = value; }
        }

        private short age;

        public short Age
        {
            get { return age; }
            set { age = value; }
        }

        private int? buildingSF;

        public int? BuildingSF
        {
            get { return buildingSF; }
            set { buildingSF = value; }
        }

        private int? landSF;

        public int? LandSF
        {
            get { return landSF; }
            set { landSF = value; }
        }

        private string totalAllBuildingSF;

        public string TotalAllBuildingSF
        {
            get { return totalAllBuildingSF; }
            set { totalAllBuildingSF = value; }
        }

        private string unitsTotal;

        public string UnitsTotal
        {
            get { return unitsTotal; }
            set { unitsTotal = value; }
        }

        private string saleDate;

        public string SaleDate
        {
            get { return saleDate; }
            set { saleDate = value; }
        }

        private int? saleAmount;

        public int? SaleAmount
        {
            get { return saleAmount; }
            set { saleAmount = value; }
        }

        private PropertyClassDTO propertyClassDTO;

        public virtual PropertyClassDTO PropertyClassDTO
        {
            get { return propertyClassDTO; }
            set { propertyClassDTO = value; }
        }

        private TownshipDTO townshipDTO;

        public virtual TownshipDTO TownshipDTO
        {
            get { return townshipDTO; }
            set { townshipDTO = value; }
        }

        private PropertyAddressDTO propertyAddressDTO;

        public virtual PropertyAddressDTO PropertyAddressDTO
        {
            get { return propertyAddressDTO; }
            set { propertyAddressDTO = value; }
        }

        private List<PropertyTagDTO> propertyTagDTOs;

        public virtual List<PropertyTagDTO> PropertyTagDTOs
        {
            get { return propertyTagDTOs; }
            set { propertyTagDTOs = value; }
        }

    }
}
