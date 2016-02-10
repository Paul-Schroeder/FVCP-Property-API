using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public interface IPropertyTag
    {
        IPropertyTagDTO Data { get; set; }
    }
}
