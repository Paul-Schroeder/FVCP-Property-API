using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Property
{
    public interface IProperty
    {
        string Pin { get; set; }
        List<string> Tags { get; set; }
        void AddTag(string tag);
    }
}
