namespace Kinogo.WebAPI.Application.Common.Authorization.Models.Contracts
{
    public interface ILoginUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
