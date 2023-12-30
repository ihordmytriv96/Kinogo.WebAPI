namespace Kinogo.WebAPI.Application.Common.Authorization.Utilities.Contracts
{
    public interface IHashProcessor
    {
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
