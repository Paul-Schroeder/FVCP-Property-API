using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Property
{
    public interface IPropertyRepository
    {
        IProperty GetByPin(string pin);
        void AddTag(string tag);
        IProperty Save(IProperty property);
    }
}
