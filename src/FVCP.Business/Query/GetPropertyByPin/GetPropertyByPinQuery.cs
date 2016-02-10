using FVCP.Domain;
using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Business.Query
{
    public class GetPropertyByPinQuery : ICQExecution<IPropertyDTO, GetPropertyByPinRequest>
    {
        IPropertyRepository _propertyRepository;

        public GetPropertyByPinQuery(IPropertyRepository propertyRepository)
        {
            this._propertyRepository = propertyRepository;
        }

        public ServiceResult<IPropertyDTO> Execute(GetPropertyByPinRequest request)
        {
            ServiceResult<IPropertyDTO> retVal = new ServiceResult<IPropertyDTO>();
            retVal.Data = _propertyRepository.GetByPin(request.Pin).Data;

            if (retVal.Data != null)
            {
                retVal.Success = true;
            }

            return retVal;
        }

    }
}
