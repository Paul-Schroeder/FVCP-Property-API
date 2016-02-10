using FVCP.Domain;
using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Business.Query
{
    public class GetPropertyTagByIdQuery : ICQExecution<IPropertyTagDTO, GetPropertyTagByIdRequest>
    {
        IPropertyTagRepository _repo;

        public GetPropertyTagByIdQuery(IPropertyTagRepository repo)
        {
            this._repo = repo;
        }

        public ServiceResult<IPropertyTagDTO> Execute(GetPropertyTagByIdRequest request)
        {
            ServiceResult<IPropertyTagDTO> retVal = new ServiceResult<IPropertyTagDTO>();
            retVal.Data = _repo.GetPropertyTagById(request.Id).Data;

            if (retVal.Data != null)
            {
                retVal.Success = true;
            }

            return retVal;
        }

    }
}
