using FVCP.Property;

namespace FVCP.Business.Command
{
    public class AddPropertyTagCommand : ICommand<AddPropertyTagRequest>
    {
        IPropertyRepository _propertyRepository;
        PropertyAddTagValidator _validator;

        public AddPropertyTagCommand(IPropertyRepository propertyRepository)
        {
            this._propertyRepository = propertyRepository;
            this._validator = new PropertyAddTagValidator();
        }

        public void Execute(AddPropertyTagRequest request)
        {
            if (_validator.IsPropertyTagValid(request.Pin, request.Tag))
            {
                IProperty property = _propertyRepository.GetByPin(request.Pin);
                if (property != null)
                {
                    property.AddTag(request.Tag);
                    //_propertyRepository.Save(property);
                }
            }
            else
            {
                throw new InvalidPropertyTagException();
            }
        }
    }
}
