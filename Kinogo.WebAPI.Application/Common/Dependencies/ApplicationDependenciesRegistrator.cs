using Kinogo.WebAPI.Application.Common.Authorization.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Kinogo.WebAPI.Application.Common.Dependencies
{
    public static class ApplicationDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            AuthorizationDependenciesRegistrator.RegisterDependencies(services);
        }
    }
}
