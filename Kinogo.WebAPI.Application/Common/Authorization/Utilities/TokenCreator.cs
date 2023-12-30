using Kinogo.WebAPI.Application.Common.Authorization.Utilities.Contracts;
using Kinogo.WebAPI.Domain.Common.Entities.RefreshToken;
using Kinogo.WebAPI.Domain.User.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Kinogo.WebAPI.Application.Common.Authorization.Utilities
{
    public class TokenCreator : ITokenCreator
    {
        private readonly IConfiguration _configuration;

        public TokenCreator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateAccessToken(UserEntity user)
        {
            List<Claim> claims = new()
            {
                new Claim("userName", user.UserName),
                new Claim("userId", user.Id),
                new Claim("userRole", user.UserRole.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddMinutes(15), signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public RefreshTokenEntity CreateRefreshToken(string userId)
        {
            var refreshToken = new RefreshTokenEntity()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Created = DateTime.Now,
                Expires = DateTime.Now.AddDays(7),
                UserId = userId
            };

            return refreshToken;
        }
    }
}
