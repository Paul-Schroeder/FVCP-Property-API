using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public interface IPropertyTagRepository
    {
        ServiceResult<IPropertyTag> AddPropertyTag(string pin, string name);
        IPropertyTag GetPropertyTagById(int id);
        ServiceResult<IPropertyTag> UpdatePropertyTag(int id, string name);
        ServiceResult<bool> DeletePropertyTag(int id);
    }
}
