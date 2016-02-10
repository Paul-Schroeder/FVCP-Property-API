using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public class Township : TownshipDTO, ITownship
    {
        public Township(ITownshipDTO data)
        {
            this.Data = data;
        }

        public ITownshipDTO Data { get; set; }
    }
}
