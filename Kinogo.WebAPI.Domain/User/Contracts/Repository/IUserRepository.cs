using Kinogo.WebAPI.Domain.Common.Repository;
using Kinogo.WebAPI.Domain.User.Entities;

namespace Kinogo.WebAPI.Domain.User.Contracts.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
    }
}
