using Kinogo.WebAPI.Application.Common.Dependencies;
using Kinogo.WebAPI.Data.Common.Dependencies;
using Kinogo.WebAPI.Host.Common.Authentication;

namespace Kinogo.WebAPI.Host.Config.Dependencies
{
    public static class DependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            MongoDbDependenciesRegistrator.RegisterDependencies(services);
            HostDependenciesRegistrator.RegisterDependencies(services);
            DataDependenciesRegistrator.RegisterDependencies(services);
            ApplicationDependenciesRegistrator.RegisterDependencies(services);
            AuthenticationRegisterDepenedencies.RegisterDependencies(services);

            // HttpContextAccessor
            services.AddHttpContextAccessor();
        }
    }
}
