using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.DTO
{
    public interface IPropertyTagDTO
    {
        int Id { get; set; }
        string Pin { get; set; }
        string Name { get; set; }
    }
}
