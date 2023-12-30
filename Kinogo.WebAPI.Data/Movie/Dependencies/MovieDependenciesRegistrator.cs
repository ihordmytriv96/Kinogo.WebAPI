using Kinogo.WebAPI.Data.Movie.Filter;
using Kinogo.WebAPI.Data.Movie.Filter.Contracts;
using Kinogo.WebAPI.Data.Movie.Repositories;
using Kinogo.WebAPI.Domain.Common.Contracts.Filter;
using Kinogo.WebAPI.Domain.Movie.Entities;
using Kinogo.WebAPI.Domain.Movie.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Kinogo.WebAPI.Data.Movie.Dependencies
{
    public static class MovieDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IMovieRepository, MongoDbMovieRepository>();
            services.AddTransient<IEntityFilter<MovieEntity, IMovieFilterModel>, MovieFilter>();
        }
    }
}
