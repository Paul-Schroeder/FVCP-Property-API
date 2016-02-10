using System;
using FVCP.Domain;
using FVCP.DTO;

namespace FVCP.Business.Command
{
    public class AddPropertyTagCommand : ICQExecution<PropertyTagDTO, AddPropertyTagRequest>
    {
        IPropertyRepository _repoProperty;
        IPropertyTagRepository _repoPropertyTag;
        AddPropertyTagValidator _validator;

        public AddPropertyTagCommand(IPropertyRepository repoProperty, IPropertyTagRepository repoPropertyTag)
        {
            this._repoProperty = repoProperty;
            this._repoPropertyTag = repoPropertyTag;
            this._validator = new AddPropertyTagValidator();
        }

        public ServiceResult<PropertyTagDTO> Execute(AddPropertyTagRequest request)
        {
            ServiceResult<PropertyTagDTO> retVal = new ServiceResult<PropertyTagDTO>();

            if (!_validator.IsPropertyTagValid(request.Pin, request.Name))
                throw new InvalidPropertyTagException();

            IProperty property = _repoProperty.GetByPin(request.Pin);
            if (property != null)
            {
                ServiceResult<IPropertyTag> newTag = _repoPropertyTag.AddPropertyTag(request.Pin, request.Name);
                retVal.Success = newTag.Success;
                retVal.ErrorID = newTag.ErrorID;
                retVal.Message = newTag.Message;
                if (newTag.Data != null)
                    retVal.Data = newTag.Data.Data;
            }
            else
            {
                retVal.Success = false;
                retVal.ErrorID = "404";
                retVal.Message = string.Format("PIN '{0}' was not found; unable to create property tag '{1}'.",
                    request.Pin, request.Name);
            }

            return retVal;
        }

    }
}
