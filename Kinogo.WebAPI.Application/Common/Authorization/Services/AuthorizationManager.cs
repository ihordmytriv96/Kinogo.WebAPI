using Kinogo.WebAPI.Application.Common.Authorization.Contracts;
using Kinogo.WebAPI.Application.Common.Authorization.Models.Contracts;
using Kinogo.WebAPI.Application.Common.Authorization.Utilities.Contracts;
using Kinogo.WebAPI.Domain.Common.Entities.RefreshToken.Repositories.Contracts;
using Kinogo.WebAPI.Domain.User.Cons;
using Kinogo.WebAPI.Domain.User.Contracts.Repository;
using Kinogo.WebAPI.Domain.User.Entities;
using Microsoft.AspNetCore.Http;

namespace Kinogo.WebAPI.Application.Common.Authorization.Services
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly IHashProcessor _hashProcessor;
        private readonly IUserRepository _userRepository;
        private readonly ITokenCreator _tokenCreator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthorizationManager(IHashProcessor hashProcessor,
            IUserRepository userRepository,
            ITokenCreator tokenCreator,
            IHttpContextAccessor httpContextAccessor,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _hashProcessor = hashProcessor;
            _userRepository = userRepository;
            _tokenCreator = tokenCreator;
            _httpContextAccessor = httpContextAccessor;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<string> LoginAsync(ILoginUserModel userModel, CancellationToken ct)
        {
            var user = (await _userRepository.FindAsync(x => x.UserName == userModel.UserName, ct)).FirstOrDefault();

            if (user == null) 
            {
                throw new Exception("Invalid login or password exception");
            }

            if (!_hashProcessor.VerifyPasswordHash(userModel.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Invalid login or password exception");
            }

            var accessToken = _tokenCreator.CreateAccessToken(user);
            var refreshToken = _tokenCreator.CreateRefreshToken(accessToken);

            var refresh = await _refreshTokenRepository.CreateAsync(refreshToken, ct);
            user.RefreshTokenId = refresh.Id;
            await _userRepository.UpdateAsync(user, ct);

            return accessToken;
        }

        public async Task LogoutAsync(CancellationToken ct)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("userId").Value;
            var user = (await _userRepository.FindOne(x => x.Id == userId, ct));
            var refreshToken = (await _refreshTokenRepository.FindOne(x => x.UserId == user.Id, ct));
            user.RefreshTokenId = String.Empty;
            await _refreshTokenRepository.RemoveAsync(refreshToken.Id, ct);
            await _userRepository.UpdateAsync(user, ct);
        }

        public async Task RegisterUserAsync(IRegistationUserModel userModel, CancellationToken ct)
        {
            var user = new UserEntity();
            _hashProcessor.CreatePasswordHash(userModel.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            user.UserName = userModel.UserName;
            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;
            user.Email = userModel.Email;
            user.Age = userModel.Age;
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.UserRole = UserRoles.DefaultUser;
            user.IsBanned = false;
            user.RegistrationDate = DateTime.Now;

            await _userRepository.CreateAsync(user, ct);
        }
    }
}
