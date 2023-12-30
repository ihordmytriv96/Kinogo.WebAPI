using Kinogo.WebAPI.Application.Common.Authorization.Contracts;
using Kinogo.WebAPI.Application.Common.Authorization.Services;
using Kinogo.WebAPI.Application.Common.Authorization.Utilities.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Kinogo.WebAPI.Application.Common.Authorization.Dependencies
{
    public static class AuthorizationDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            TokenDependenciesRegistator.RegisterDependencies(services);
            services.AddTransient<IAuthorizationManager, AuthorizationManager>();
        }
    }
}
