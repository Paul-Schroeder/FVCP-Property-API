using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.DTO
{
    public class TownshipDTO : ITownshipDTO
    {
        public int TownNum { get; set; }
        public string Name { get; set; }
    }
}
