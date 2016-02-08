using FVCP.Business;

namespace FVCP.Infrastructure
{
    public interface IRequestProcessor
    {
        void Process<TRequest>(TRequest request) where TRequest : IRequest;
    }
}
