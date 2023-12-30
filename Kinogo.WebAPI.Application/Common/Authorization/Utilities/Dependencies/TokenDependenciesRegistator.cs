using Kinogo.WebAPI.Application.Common.Authorization.Utilities.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Kinogo.WebAPI.Application.Common.Authorization.Utilities.Dependencies
{
    public static class TokenDependenciesRegistator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IHashProcessor, HashProcessor>();
            services.AddTransient<ITokenCreator, TokenCreator>();
            services.AddTransient<ITokenRefresher, TokenRefresher>();
        }
    }
}
