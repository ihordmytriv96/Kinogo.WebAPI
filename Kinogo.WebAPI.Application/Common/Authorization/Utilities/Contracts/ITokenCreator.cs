using Kinogo.WebAPI.Domain.Common.Entities.RefreshToken;
using Kinogo.WebAPI.Domain.User.Entities;

namespace Kinogo.WebAPI.Application.Common.Authorization.Utilities.Contracts
{
    public interface ITokenCreator
    {
        public string CreateAccessToken(UserEntity user);
        public RefreshTokenEntity CreateRefreshToken(string userId);
    }
}
