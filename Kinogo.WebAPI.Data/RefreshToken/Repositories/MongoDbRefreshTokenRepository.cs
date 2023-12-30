using Kinogo.WebAPI.Data.Common.Config.MongoDb.Contracts;
using Kinogo.WebAPI.Data.Common.Repository;
using Kinogo.WebAPI.Domain.Common.Entities.RefreshToken;
using Kinogo.WebAPI.Domain.Common.Entities.RefreshToken.Repositories.Contracts;

namespace Kinogo.WebAPI.Data.RefreshToken.Repositories
{
    public class MongoDbRefreshTokenRepository : MongoDbBaseRepository<RefreshTokenEntity>, IRefreshTokenRepository
    {
        public MongoDbRefreshTokenRepository(IMongoDbSettings settings) : base(settings)
        {
        }

        public override string CollectionName { get; set; } = "RefreshTokens";
    }
}
