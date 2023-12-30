using Kinogo.WebAPI.Application.Common.Authorization.Utilities.Contracts;
using Kinogo.WebAPI.Domain.Common.Entities.RefreshToken.Repositories.Contracts;
using Kinogo.WebAPI.Domain.User.Contracts.Repository;
using Microsoft.AspNetCore.Http;

namespace Kinogo.WebAPI.Application.Common.Authorization.Utilities
{
    public class TokenRefresher : ITokenRefresher
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenCreator _tokenCreator;
        private readonly IUserRepository _userRepository;

        public TokenRefresher(IHttpContextAccessor httpContextAccessor,
            IRefreshTokenRepository refreshTokenRepository,
            ITokenCreator tokenCreator,
            IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenCreator = tokenCreator;
            _userRepository = userRepository;
        }

        public async Task<string> RefreshTokensAsync(CancellationToken ct)
        {
            var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refreshToken"];
            var token = (await _refreshTokenRepository.FindAsync(x => x.Token == refreshToken, ct)).FirstOrDefault();

            if (token == null) 
            {
                throw new InvalidOperationException();
            }

            if (token.Expires < DateTime.Now)
            {
                throw new InvalidOperationException();
            }

            var user = (await _userRepository.FindOne(x => x.RefreshTokenId == token.Id, ct));
            string accessToken = _tokenCreator.CreateAccessToken(user);
            var newRefreshToken = _tokenCreator.CreateRefreshToken(accessToken);
            user.RefreshTokenId = newRefreshToken.Id;
            newRefreshToken.Id = token.Id;
            await _refreshTokenRepository.UpdateAsync(newRefreshToken, ct);
            await _userRepository.UpdateAsync(user, ct);

            return accessToken;
        }
    }
}
