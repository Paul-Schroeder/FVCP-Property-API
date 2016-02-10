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
    public class PropertyAddressDTO : IPropertyAddressDTO
    {
        private string _pin;

        public string Pin
        {
            get { return _pin; }
            set { _pin = value; }
        }

        private string _houseNum;

        public string HouseNum
        {
            get { return _houseNum; }
            set { _houseNum = value; }
        }

        private string _streetDir;

        public string StreetDir
        {
            get { return _streetDir; }
            set { _streetDir = value; }
        }

        private string _street;

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        
        private string _suffix;

        public string Suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }

        private string _apt;

        public string Apt
        {
            get { return _apt; }
            set { _apt = value; }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private short? _zip;

        public short? Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

    }
}
