using Newtonsoft.Json;

namespace Kinogo.WebAPI.Host.Movie.Models
{
    public class CreateMovieModel
    {
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

        [JsonProperty("movieMainActors")]
        public List<string> MovieMainActors { get; set; }

        [JsonProperty("movieProducers")]
        public List<string> MovieProducers { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("movieGenresids")]
        public List<string> MovieGenresIds { get; set; }
    }
}
