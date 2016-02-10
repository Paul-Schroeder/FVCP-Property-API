using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public interface IProperty
    {
        PropertyDTO Data { get; set; }

        IPropertyClass PropertyClass { get; set; }
        ITownship Township { get; set; }
        IPropertyAddress PropertyAddress { get; set; }
        List<IPropertyTag> PropertyTags { get; set; }

//        void AddPropertyTag(string tag);
    }
}
