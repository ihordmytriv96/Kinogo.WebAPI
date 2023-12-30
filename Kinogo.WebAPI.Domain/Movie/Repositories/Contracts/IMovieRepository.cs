using Kinogo.WebAPI.Domain.Common.Repository;
using Kinogo.WebAPI.Domain.Movie.Entities;

namespace Kinogo.WebAPI.Domain.Movie.Repositories.Contracts
{
    public interface IMovieRepository : IBaseRepository<MovieEntity>
    {
    }
}
