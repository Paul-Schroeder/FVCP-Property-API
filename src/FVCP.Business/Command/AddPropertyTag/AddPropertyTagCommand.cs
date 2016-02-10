using FVCP.Domain;

namespace FVCP.Business.Command
{
    public class AddPropertyTagCommand : ICQExecution<string, AddPropertyTagRequest>
    {
        IPropertyRepository _propertyRepository;
        PropertyAddTagValidator _validator;

        public AddPropertyTagCommand(IPropertyRepository propertyRepository)
        {
            this._propertyRepository = propertyRepository;
            this._validator = new PropertyAddTagValidator();
        }

        public ServiceResult<string> Execute(AddPropertyTagRequest request)
        {
            ServiceResult<string> retVal = new ServiceResult<string>();

            if (!_validator.IsPropertyTagValid(request.Pin, request.Tag))
                throw new InvalidPropertyTagException();

            IProperty property = _propertyRepository.GetByPin(request.Pin);
            if (property != null)
            {
                property.AddPropertyTag(request.Tag);
                //_propertyRepository.Save(property);
                retVal.Success = true;
            }

            return retVal;
        }
    }
}
