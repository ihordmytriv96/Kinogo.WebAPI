using Kinogo.WebAPI.Application.Common.Authorization.Models.Contracts;
using Newtonsoft.Json;

namespace Kinogo.WebAPI.Host.User.Models
{
    public class RegistationUserModel : IRegistationUserModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}
