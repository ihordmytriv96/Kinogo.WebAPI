using Kinogo.WebAPI.Data.Movie.Filter.Contracts;
using Kinogo.WebAPI.Domain.Common.Contracts.Filter;
using Kinogo.WebAPI.Domain.Movie.Entities;
using Kinogo.WebAPI.Domain.Movie.Repositories.Contracts;
using Kinogo.WebAPI.Host.Common.Controllers;
using Kinogo.WebAPI.Host.Common.Mapper.Contracts;
using Kinogo.WebAPI.Host.Movie.Models;
using Kinogo.WebAPI.Host.Movie.Utilities.Contracts;
using Kinogo.WebAPI.Host.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Kinogo.WebAPI.Host.Movie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : BaseController
    {
        private readonly IBaseMapper<CreateMovieModel, MovieEntity> _createMovieMapper;
        private readonly IMovieRepository _movieRepository;
        private readonly IBaseMapper<MovieEntity, MovieModel> _movieModelMapper;
        private readonly IEntityFilter<MovieEntity, IMovieFilterModel> _movieFilter;
        private readonly IGenresFillingHandler _genresFillingHandler;

        public MovieController(IBaseMapper<CreateMovieModel, MovieEntity> createMovieMapper,
            IMovieRepository movieRepository,
            IBaseMapper<MovieEntity, MovieModel> movieModelMapper,
            IEntityFilter<MovieEntity, IMovieFilterModel> movieFilter,
            IGenresFillingHandler genresFillingHandler)
        {
            _createMovieMapper = createMovieMapper;
            _movieRepository = movieRepository;
            _movieModelMapper = movieModelMapper;
            _movieFilter = movieFilter;
            _genresFillingHandler = genresFillingHandler;
        }

        [HttpPost]
        public async Task<ActionResult<MovieModel>> Create(CreateMovieModel model, CancellationToken ct)
        {
            var count = await _movieRepository.FindOne(x => x.Name == model.Name, ct);

            if (count != null)
            {
                return Ok("this name is already in use");
            }

            var movieEntity = _createMovieMapper.Map(model);
            var result = await _movieRepository.CreateAsync(movieEntity, ct);
            var movieModel = _movieModelMapper.Map(movieEntity);

            await _genresFillingHandler.FillModel(movieModel, ct);

            return Ok(movieModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieModel>> GetById(string id, CancellationToken ct)
        {
            var movie = await _movieRepository.FindOne(x => x.Id == id, ct);
            if (movie == null)
            {
                return Ok("dont have movie with this name");
            }

            var movieModel = _movieModelMapper.Map(movie);
            await _genresFillingHandler.FillModel(movieModel, ct);

            return Ok(movieModel);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<MovieModel>>> Search([FromQuery] MovieFilterModel filterModel, [FromQuery] PaginationParameters paginationParameters, CancellationToken ct)
        {
            var count = await _movieRepository.GetCountAsync(_movieFilter.Filter(filterModel), ct);

            if (count == 0)
            {
                return NoContent();
            }

            var movies = (await _movieRepository.FindAsync(_movieFilter.Filter(filterModel), ct)).ToList();

            var moviesModels = movies.Select(x => _movieModelMapper.Map(x)).ToList();

            await _genresFillingHandler.FillModel(moviesModels, ct);

            return OkPaged(moviesModels, paginationParameters, count);
        }
    }

    
}
