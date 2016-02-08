namespace FVCP.Business
{
    /// <summary>
    /// Marker interface for commands.
    /// </summary>
    public interface ICommand<in TRequest> where TRequest : IRequest
    {
        void Execute(TRequest request);
    }
}
