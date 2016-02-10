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
    public class PropertyClassDTO
    {
        private short classNum;

        public short ClassNum
        {
            get { return classNum; }
            set { classNum = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
