using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Business.Command
{
    public class DeletePropertyTagRequest : IRequest
    {
        public int Id { get; set; }
    }
}
