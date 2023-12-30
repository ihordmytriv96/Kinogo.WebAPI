namespace Kinogo.WebAPI.Application.Common.Authorization.Utilities.Contracts
{
    public interface ITokenRefresher
    {
        public Task<string> RefreshTokensAsync(CancellationToken cancellationToken);
    }
}
