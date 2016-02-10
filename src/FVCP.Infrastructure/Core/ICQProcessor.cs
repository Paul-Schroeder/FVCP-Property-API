using FVCP.Business;
using FVCP.DTO;

namespace FVCP.Infrastructure
{
    public interface ICQProcessor<T>
    {
        ServiceResult<T> Process<TRequest>(TRequest request) 
            where TRequest : IRequest;
    }
}
