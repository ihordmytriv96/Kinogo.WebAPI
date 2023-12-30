using Kinogo.WebAPI.Data.Common.Config.MongoDb.Contracts;
using Kinogo.WebAPI.Data.Common.Repository;
using Kinogo.WebAPI.Domain.User.Contracts.Repository;
using Kinogo.WebAPI.Domain.User.Entities;

namespace Kinogo.WebAPI.Data.User.Repositories
{
    public class MongoDbUserRepository : MongoDbBaseRepository<UserEntity>, IUserRepository
    {
        public MongoDbUserRepository(IMongoDbSettings settings) : base(settings)
        {
        }

        public override string CollectionName { get; set; } = "Users";
    }
}
