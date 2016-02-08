using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FVCP.Infrastructure.Logging;

namespace FVCP.Infrastructure.DependencyInjection
{
    public class Infrastructure : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ExceptionLogger>());
            container.Register(Component.For<IRequestProcessor>().ImplementedBy<RequestProcessor>());
        }
    }
}
