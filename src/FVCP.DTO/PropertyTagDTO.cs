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
    public class PropertyTagDTO : IPropertyTagDTO
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _pin;

        public string Pin
        {
            get { return _pin; }
            set { _pin = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
