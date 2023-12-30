using Kinogo.WebAPI.Domain.Movie.Entities;
using Kinogo.WebAPI.Host.Common.Mapper.Contracts;
using Kinogo.WebAPI.Host.Movie.Models;

namespace Kinogo.WebAPI.Host.Movie.Mappers
{
    public class MovieModelMapper : IBaseMapper<MovieEntity, MovieModel>
    {
        public MovieModel Map(MovieEntity map)
        => new()
        {
            Id = map.Id,
            Country = map.Country,
            CreationYear = map.CreationYear,
            Description = map.Description,
            MovieMainActors = map.MovieMainActors,
            MovieProducers = map.MovieProducers,
            Name = map.Name,
            PathToMovie = map.PathToMovie,
            PathToMovieLogo = map.PathToMovieLogo
        };
    }
}
