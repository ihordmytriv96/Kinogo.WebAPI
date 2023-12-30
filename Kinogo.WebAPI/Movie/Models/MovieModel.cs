using Kinogo.WebAPI.Host.Genre.Models;
using Newtonsoft.Json;

namespace Kinogo.WebAPI.Host.Movie.Models
{
    public class MovieModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pathToMovie")]
        public string PathToMovie { get; set; }

        [JsonProperty("creationYear")]
        public int CreationYear { get; set; }

        [JsonProperty("pathToMovieLogo")]
        public string PathToMovieLogo { get; set; }

        [JsonProperty("movieGenres")]
        public List<GenreModel> MovieGenres { get; set; } = new();

        [JsonProperty("movieMainActors")]
        public List<string> MovieMainActors { get; set; } = new();

        [JsonProperty("movieProducers")]
        public List<string> MovieProducers { get; set; } = new();

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
