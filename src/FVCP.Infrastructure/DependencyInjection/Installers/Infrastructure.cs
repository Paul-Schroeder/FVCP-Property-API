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
            container.Register(Component
                .For<ILoggingService>()
                .ImplementedBy<Log4NetLoggingService>()
                .LifestyleSingleton()
                );

            container.Register(Component.For<ExceptionLogger>());
            
            //container.Register(Component.For<IRequestProcessor>().ImplementedBy<RequestProcessor>());
            container.Register(Component
                .For(typeof(ICQProcessor<>))
                .ImplementedBy(typeof(CQProcessor<>))
                .LifestylePerWebRequest());
        }
    }
}
