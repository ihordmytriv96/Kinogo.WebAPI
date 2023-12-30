using Kinogo.WebAPI.Application.Common.Authorization.Models.Contracts;
using Newtonsoft.Json;

namespace Kinogo.WebAPI.Host.User.Models
{
    public class LoginUserModel : ILoginUserModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
