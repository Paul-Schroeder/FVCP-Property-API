using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FVCP.Property;

namespace FVCP.Infrastructure.DependencyInjection
{
    public class Domain : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<PropertyFactory>()
                                      .Where(type => type.Name.EndsWith("Factory"))
                                      .WithServiceSelf()
                                      .LifestyleSingleton());
        }
    }
}
