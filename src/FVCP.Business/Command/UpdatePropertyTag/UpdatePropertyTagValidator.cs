using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Business.Command
{
    public class UpdatePropertyTagValidator
    {
        public bool IsPropertyTagValid(string tag)
        {
            return !(string.IsNullOrEmpty(tag));
        }
    }
}
