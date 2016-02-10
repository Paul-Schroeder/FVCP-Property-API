using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.DTO
{
    public class PropertyTagDTO : IPropertyTagDTO
    {
        public int Id { get; set; }
        public string Pin { get; set; }
        public string Name { get; set; }
    }
}
