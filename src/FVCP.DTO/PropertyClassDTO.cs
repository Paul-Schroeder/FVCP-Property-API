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
    public class PropertyClassDTO : IPropertyClassDTO
    {
        private short _classNum;

        public short ClassNum
        {
            get { return _classNum; }
            set { _classNum = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


    }
}
