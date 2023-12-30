using Kinogo.WebAPI.Data.Common.Config.MongoDb.Contracts;
using Kinogo.WebAPI.Data.Common.Repository;
using Kinogo.WebAPI.Domain.Movie.Entities;
using Kinogo.WebAPI.Domain.Movie.Repositories.Contracts;

namespace Kinogo.WebAPI.Data.Movie.Repositories
{
    public class MongoDbMovieRepository : MongoDbBaseRepository<MovieEntity>, IMovieRepository
    {
        public MongoDbMovieRepository(IMongoDbSettings settings) : base(settings)
        {
        }

        public override string CollectionName { get; set; } = "Movies";

    }
}
