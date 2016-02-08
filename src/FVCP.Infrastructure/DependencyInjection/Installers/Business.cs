using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FVCP.Infrastructure.Logging;
using FVCP.Business.Command;
using FVCP.Business.Query;

namespace FVCP.Infrastructure.DependencyInjection
{
    public class Business : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<GetPropertyByPinQuery>()
                          .Where(type => type.Name.EndsWith("Query"))
                          .WithServiceSelf()
                          .WithServiceFirstInterface()
                          .Configure(c => c.LifestyleSingleton().Interceptors<ExceptionLogger>()));

            container.Register(Classes.FromAssemblyContaining<AddPropertyTagCommand>()
                                      .Where(type => type.Name.EndsWith("Command"))
                                      .WithServiceSelf()
                                      .WithServiceFirstInterface()
                                      .Configure(c => c.LifestyleSingleton().Interceptors<ExceptionLogger>()));
        }
    }
}