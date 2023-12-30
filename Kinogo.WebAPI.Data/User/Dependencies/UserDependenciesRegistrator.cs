using Kinogo.WebAPI.Data.User.Repositories;
using Kinogo.WebAPI.Domain.User.Contracts.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Kinogo.WebAPI.Data.User.Dependencies
{
    public static class UserDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, MongoDbUserRepository>();
        }
    }
}
