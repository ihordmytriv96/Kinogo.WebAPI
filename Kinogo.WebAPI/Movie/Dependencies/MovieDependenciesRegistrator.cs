using Kinogo.WebAPI.Domain.Movie.Entities;
using Kinogo.WebAPI.Host.Common.Mapper.Contracts;
using Kinogo.WebAPI.Host.Movie.Mappers;
using Kinogo.WebAPI.Host.Movie.Models;
using Kinogo.WebAPI.Host.Movie.Utilities;
using Kinogo.WebAPI.Host.Movie.Utilities.Contracts;

namespace Kinogo.WebAPI.Host.Movie.Dependencies
{
    public static class MovieDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IBaseMapper<CreateMovieModel, MovieEntity>, CreateMovieMapper>();
            services.AddTransient<IBaseMapper<MovieEntity, MovieModel>, MovieModelMapper>();
            services.AddTransient<IGenresFillingHandler, GenresFillingHandler>();
        }
    }
}
