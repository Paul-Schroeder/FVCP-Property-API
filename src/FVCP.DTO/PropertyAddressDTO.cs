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
    public class PropertyAddressDTO
    {
        private string pin;

        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        private string houseNum;

        public string HouseNum
        {
            get { return houseNum; }
            set { houseNum = value; }
        }

        private string streetDir;

        public string StreetDir
        {
            get { return streetDir; }
            set { streetDir = value; }
        }

        private string street;

        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        
        private string suffix;

        public string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }

        private string apt;

        public string Apt
        {
            get { return apt; }
            set { apt = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private short? zip;

        public short? Zip
        {
            get { return zip; }
            set { zip = value; }
        }

    }
}
