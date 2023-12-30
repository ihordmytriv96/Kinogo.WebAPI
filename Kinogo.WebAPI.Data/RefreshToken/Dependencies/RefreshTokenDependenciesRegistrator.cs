using Kinogo.WebAPI.Data.RefreshToken.Repositories;
using Kinogo.WebAPI.Domain.Common.Entities.RefreshToken.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Kinogo.WebAPI.Data.RefreshToken.Dependencies
{
    public static class RefreshTokenDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services) 
        {
            services.AddTransient<IRefreshTokenRepository, MongoDbRefreshTokenRepository>();
        }
    }
}
