using Newtonsoft.Json;

namespace Kinogo.WebAPI.Host.Genre.Models
{
    public class GenreModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
