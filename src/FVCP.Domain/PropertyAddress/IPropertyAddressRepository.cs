using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public interface IPropertyAddressRepository
    {
        IPropertyAddress GetByPin(string pin);
    }
}
