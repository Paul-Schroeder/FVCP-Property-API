using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.DTO
{
    [Serializable]
    public class TownshipDTO
    {
        private int townNum;

        public int TownNum
        {
            get { return townNum; }
            set { townNum = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
