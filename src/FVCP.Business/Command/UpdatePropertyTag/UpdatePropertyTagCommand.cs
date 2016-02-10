using System;
using FVCP.Domain;
using FVCP.DTO;

namespace FVCP.Business.Command
{
    public class UpdatePropertyTagCommand : ICQExecution<PropertyTagDTO, UpdatePropertyTagRequest>
    {
        IPropertyTagRepository _repoPropertyTag;
        UpdatePropertyTagValidator _validator;

        public UpdatePropertyTagCommand(IPropertyTagRepository repoPropertyTag)
        {
            this._repoPropertyTag = repoPropertyTag;
            this._validator = new UpdatePropertyTagValidator();
        }

        public ServiceResult<PropertyTagDTO> Execute(UpdatePropertyTagRequest request)
        {
            ServiceResult<PropertyTagDTO> retVal = new ServiceResult<PropertyTagDTO>();

            if (!_validator.IsPropertyTagValid(request.Name))
                throw new InvalidPropertyTagException();

            ServiceResult<IPropertyTag> newTag = _repoPropertyTag.UpdatePropertyTag(request.Id, request.Name);
            retVal.Success = newTag.Success;
            retVal.ErrorID = newTag.ErrorID;
            retVal.Message = newTag.Message;
            if (newTag.Data != null)
                retVal.Data = newTag.Data.Data;

            return retVal;
        }

    }
}
