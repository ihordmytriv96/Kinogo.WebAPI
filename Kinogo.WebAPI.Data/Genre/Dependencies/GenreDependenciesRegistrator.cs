using Kinogo.WebAPI.Data.Genre.Repositories;
using Kinogo.WebAPI.Domain.Genre.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Kinogo.WebAPI.Data.Genre.Dependencies
{
    public static class GenreDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IGenreRepository, MongoDbGenreRespository>();
        }
    }
}
