using FVCP.Property;
using FVCP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Business.Query
{
    public class GetPropertyByPinQuery
    {
        IPropertyRepository _propertyRepository;

        public GetPropertyByPinQuery(IPropertyRepository propertyRepository)
        {
            this._propertyRepository = propertyRepository;
        }

        public ServiceResult<IProperty> Execute(string pin)
        {
            ServiceResult<IProperty> retVal = new ServiceResult<IProperty>();
            retVal.Data = _propertyRepository.GetByPin(pin);
            return retVal;
        }

    }
}
