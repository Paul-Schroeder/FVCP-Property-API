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
    public class PropertyTagDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string pin;

        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
