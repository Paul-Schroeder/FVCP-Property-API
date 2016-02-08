using Castle.Facilities.Logging;
using Castle.Windsor;

namespace FVCP.Infrastructure.DependencyInjection
{
    public class CompositionRoot
    {
        public virtual void ComposeApplication(IWindsorContainer container)
        {
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net());

            container.Install(
                new Infrastructure(),
                new Persistence(),
                new Domain(),
                new Business()
            );
        }
    }
}
