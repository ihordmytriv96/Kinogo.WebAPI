using Kinogo.WebAPI.Host.Movie.Models;

namespace Kinogo.WebAPI.Host.Movie.Utilities.Contracts
{
    public interface IGenresFillingHandler
    {
        public Task FillModel(MovieModel model, CancellationToken ct);
        public Task FillModel(IEnumerable<MovieModel> models, CancellationToken ct);
    }
}
