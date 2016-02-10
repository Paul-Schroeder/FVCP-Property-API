using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public class Township : ITownship
    {
        public Township(TownshipDTO data)
        {
            this.Data = data;
        }

        public TownshipDTO Data { get; set; }
    }
}
