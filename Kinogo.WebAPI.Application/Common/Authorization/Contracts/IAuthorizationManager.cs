using Kinogo.WebAPI.Application.Common.Authorization.Models.Contracts;

namespace Kinogo.WebAPI.Application.Common.Authorization.Contracts
{
    public interface IAuthorizationManager
    {
        public Task<string> LoginAsync(ILoginUserModel userModel, CancellationToken ct);
        public Task RegisterUserAsync(IRegistationUserModel userModel, CancellationToken ct);
        public Task LogoutAsync(CancellationToken ct);
    }
}
