using FVCP.Domain;
using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Business.Query
{
    public class GetPropertyByPinQuery : ICQExecution<PropertyDTO, GetPropertyByPinRequest>
    {
        IPropertyRepository _propertyRepository;

        public GetPropertyByPinQuery(IPropertyRepository propertyRepository)
        {
            this._propertyRepository = propertyRepository;
        }

        public ServiceResult<PropertyDTO> Execute(GetPropertyByPinRequest request)
        {
            ServiceResult<PropertyDTO> retVal = new ServiceResult<PropertyDTO>();
            retVal.Data = _propertyRepository.GetByPin(request.Pin).Data;

            if (retVal.Data != null)
            {
                retVal.Success = true;
            }

            return retVal;
        }

    }
}
