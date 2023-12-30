using Kinogo.WebAPI.Domain.Genre.Entities;
using Kinogo.WebAPI.Domain.Genre.Repositories;
using Kinogo.WebAPI.Domain.Movie.Repositories.Contracts;
using Kinogo.WebAPI.Host.Common.Mapper.Contracts;
using Kinogo.WebAPI.Host.Genre.Models;
using Kinogo.WebAPI.Host.Movie.Models;
using Kinogo.WebAPI.Host.Movie.Utilities.Contracts;

namespace Kinogo.WebAPI.Host.Movie.Utilities
{
    public class GenresFillingHandler : IGenresFillingHandler
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IBaseMapper<GenreEntity, GenreModel> _genreModelMapper;

        public GenresFillingHandler(IGenreRepository genreRepository, 
                IMovieRepository movieRepository,
                IBaseMapper<GenreEntity, GenreModel> genreModelMapper)
        {
            _genreRepository = genreRepository;
            _movieRepository = movieRepository;
            _genreModelMapper = genreModelMapper;
        }

        public async Task FillModel(MovieModel model, CancellationToken ct)
        {
            var movie = await _movieRepository.GetByIdAsync(model.Id, ct);

            foreach (var genresId in movie.MovieGenresIds) 
            {
                var genre = await _genreRepository.GetByIdAsync(genresId, ct);
                var genreModel = _genreModelMapper.Map(genre);
                model.MovieGenres.Add(genreModel);
            }
        }

        public async Task FillModel(IEnumerable<MovieModel> models, CancellationToken ct)
        {
            foreach (var model in models)
            {
                await FillModel(model, ct);
            }
        }
    }
}
