namespace FVCP.Business
{
    /// <summary>
    /// Marker interface for commands and queries using CQRS pattern.
    /// </summary>
    public interface ICQExecution<TData, in TRequest> 
        //where TServiceResult : ServiceResult<TData>
        where TRequest : IRequest
    {
        ServiceResult<TData> Execute(TRequest request);
    }
}
