using System;
using FVCP.Domain;
using FVCP.DTO;

namespace FVCP.Business.Command
{
    public class DeletePropertyTagCommand : ICQExecution<bool, DeletePropertyTagRequest>
    {
        IPropertyTagRepository _repoPropertyTag;

        public DeletePropertyTagCommand(IPropertyTagRepository repoPropertyTag)
        {
            this._repoPropertyTag = repoPropertyTag;
        }

        public ServiceResult<bool> Execute(DeletePropertyTagRequest request)
        {
            ServiceResult<bool> retVal = new ServiceResult<bool>();

            ServiceResult<bool> newTag = _repoPropertyTag.DeletePropertyTag(request.Id);
            retVal.Success = newTag.Success;
            retVal.ErrorID = newTag.ErrorID;
            retVal.Message = newTag.Message;
            retVal.Data = newTag.Data;

            return retVal;
        }

    }
}
