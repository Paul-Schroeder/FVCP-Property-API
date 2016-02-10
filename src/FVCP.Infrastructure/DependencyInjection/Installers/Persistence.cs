using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FVCP.Domain;
//using MongoDB.Driver;
using FVCP.Persistence;

namespace FVCP.Infrastructure.DependencyInjection
{
    public class Persistence : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //RegiterMongoDb(container);
            RegisterRepositories(container);
        }

        //protected virtual void RegiterMongoDb(IWindsorContainer container)
        //{
        //    var mongoClient = new MongoClient("mongodb://localhost");
        //    container.Register(Component.For<MongoClient>().Instance(mongoClient));
        //}

        void RegisterRepositories(IWindsorContainer container)
        {
            container.Register(Classes.FromAssemblyContaining<PropertyRepository>()
                          .Where(type => type.Name.EndsWith("Repository"))
                          .WithServiceSelf()
                          //.BasedOn<IPropertyRepository>()
                          .WithServiceFirstInterface()
                          .LifestyleSingleton());
        }
    }
}
