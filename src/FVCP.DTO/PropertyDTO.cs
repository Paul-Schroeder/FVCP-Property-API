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
    /// for serialization purposes.  This avoids properties coming out with names like '...k__BackingField'.
    /// </remarks>
    [Serializable]
    public class PropertyDTO : IPropertyDTO
    {
        public PropertyDTO()
        {
            this.PropertyTagDTOs = new List<IPropertyTagDTO>();
        }

        private string _pin;

        public string Pin
        {
            get { return _pin; }
            set { _pin = value; }
        }

        private short _classNum;

        public short ClassNum
        {
            get { return _classNum; }
            set { _classNum = value; }
        }

        private int _townNum;

        public int TownNum
        {
            get { return _townNum; }
            set { _townNum = value; }
        }

        private short? _volume;

        public short? Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        private string _locationId;

        public string LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        private int _taxCode;

        public int TaxCode
        {
            get { return _taxCode; }
            set { _taxCode = value; }
        }

        private int _neighborhoodId;

        public int NeighborhoodId
        {
            get { return _neighborhoodId; }
            set { _neighborhoodId = value; }
        }

        private short? _homeImpYear;

        public short? HomeImpYear
        {
            get { return _homeImpYear; }
            set { _homeImpYear = value; }
        }

        private string _resType;

        public string ResType
        {
            get { return _resType; }
            set { _resType = value; }
        }

        private string _buildingUse;

        public string BuildingUse
        {
            get { return _buildingUse; }
            set { _buildingUse = value; }
        }

        private string _aptCount;

        public string AptCount
        {
            get { return _aptCount; }
            set { _aptCount = value; }
        }

        private string _commUnits;

        public string CommUnits
        {
            get { return _commUnits; }
            set { _commUnits = value; }
        }

        private string  _extDesc;

        public string ExtDesc
        {
            get { return _extDesc; }
            set { _extDesc = value; }
        }

        private byte? _fullBath;

        public byte? FullBath
        {
            get { return _fullBath; }
            set { _fullBath = value; }
        }

        private byte? _halfBath;

        public byte? HalfBath
        {
            get { return _halfBath; }
            set { _halfBath = value; }
        }

        private string _basementDesc;

        public string BasementDesc
        {
            get { return _basementDesc; }
            set { _basementDesc = value; }
        }

        private string _atticDesc;

        public string AtticDesc
        {
            get { return _atticDesc; }
            set { _atticDesc = value; }
        }

        private byte? _airCond;

        public byte? AirCond
        {
            get { return _airCond; }
            set { _airCond = value; }
        }

        private byte? _firePlace;

        public byte? Fireplace
        {
            get { return _firePlace; }
            set { _firePlace = value; }
        }

        private string _garageDesc;

        public string GarageDesc
        {
            get { return _garageDesc; }
            set { _garageDesc = value; }
        }

        private short _age;

        public short Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private int? _buildingSF;

        public int? BuildingSF
        {
            get { return _buildingSF; }
            set { _buildingSF = value; }
        }

        private int? _landSF;

        public int? LandSF
        {
            get { return _landSF; }
            set { _landSF = value; }
        }

        private string _totalAllBuildingSF;

        public string TotalAllBuildingSF
        {
            get { return _totalAllBuildingSF; }
            set { _totalAllBuildingSF = value; }
        }

        private string _unitsTotal;

        public string UnitsTotal
        {
            get { return _unitsTotal; }
            set { _unitsTotal = value; }
        }

        private string _saleDate;

        public string SaleDate
        {
            get { return _saleDate; }
            set { _saleDate = value; }
        }

        private int? _saleAmount;

        public int? SaleAmount
        {
            get { return _saleAmount; }
            set { _saleAmount = value; }
        }

        private IPropertyClassDTO _propertyClassDTO;

        public virtual IPropertyClassDTO PropertyClassDTO
        {
            get { return _propertyClassDTO; }
            set { _propertyClassDTO = value; }
        }

        private ITownshipDTO _townshipDTO;

        public virtual ITownshipDTO TownshipDTO
        {
            get { return _townshipDTO; }
            set { _townshipDTO = value; }
        }

        private IPropertyAddressDTO _propertyAddressDTO;

        public virtual IPropertyAddressDTO PropertyAddressDTO
        {
            get { return _propertyAddressDTO; }
            set { _propertyAddressDTO = value; }
        }

        private List<IPropertyTagDTO> _propertyTagDTOs;

        public virtual List<IPropertyTagDTO> PropertyTagDTOs
        {
            get { return _propertyTagDTOs; }
            set { _propertyTagDTOs = value; }
        }

    }
}
