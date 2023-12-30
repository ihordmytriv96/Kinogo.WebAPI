using Kinogo.WebAPI.Application.Common.Authorization.Contracts;
using Kinogo.WebAPI.Application.Common.Authorization.Utilities.Contracts;
using Kinogo.WebAPI.Host.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kinogo.WebAPI.Host.Authorization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationManager _authorizationManager;
        private readonly ITokenRefresher _tokenRefresher;

        public AuthorizationController(IAuthorizationManager authorizationManager,
            ITokenRefresher tokenRefresher)
        {
            _authorizationManager = authorizationManager;
            _tokenRefresher = tokenRefresher;
        }

        [HttpPost()]
        public async Task<ActionResult> Login([FromBody] LoginUserModel model, CancellationToken ct)
        {
            var accessToken = await _authorizationManager.LoginAsync(model, ct);
            return Ok(accessToken);
        }

        [Authorize]
        [HttpDelete("logout")]
        public async Task<ActionResult> Logout(CancellationToken token)
        {
            await _authorizationManager.LogoutAsync(token);

            return Ok("Successfully");
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegistationUserModel model, CancellationToken ct)
        {

            await _authorizationManager.RegisterUserAsync(model, ct);

            return Ok("Register complite");
        }

        [HttpGet("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken(CancellationToken ct)
        {
            var result = await _tokenRefresher.RefreshTokensAsync(ct);

            return Ok(result);
        }
    }
}
