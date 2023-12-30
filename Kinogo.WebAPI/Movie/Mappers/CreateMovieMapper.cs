using Kinogo.WebAPI.Domain.Movie.Entities;
using Kinogo.WebAPI.Host.Common.Mapper.Contracts;
using Kinogo.WebAPI.Host.Movie.Models;

namespace Kinogo.WebAPI.Host.Movie.Mappers
{
    public class CreateMovieMapper : IBaseMapper<CreateMovieModel, MovieEntity>
    {
        public MovieEntity Map(CreateMovieModel map)
        => new MovieEntity()
        {
            Country = map.Country,
            MovieProducers = map.MovieProducers,
            PathToMovieLogo = map.PathToMovieLogo,
            CreationYear = map.CreationYear,
            Description = map.Description,
            MovieGenresIds = map.MovieGenresIds,
            MovieMainActors = map.MovieMainActors,
            Name = map.Name,
            PathToMovie = map.PathToMovie
        };
    }
}
