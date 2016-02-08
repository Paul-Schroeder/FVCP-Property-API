using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Property
{
    public class PropertyFactory
    {
        public virtual IProperty Create()
        {
            return new Property();
        }
    }
}
