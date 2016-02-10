using FVCP.Business;

namespace FVCP.Infrastructure
{
    public interface ICQProcessor<T>
    {
        ServiceResult<T> Process<TRequest>(TRequest request) 
            where TRequest : IRequest;
    }
}
