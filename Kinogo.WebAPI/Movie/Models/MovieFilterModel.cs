using Kinogo.WebAPI.Data.Movie.Filter.Contracts;
using Newtonsoft.Json;

namespace Kinogo.WebAPI.Host.Movie.Models
{
    public class MovieFilterModel : IMovieFilterModel
    {
        [JsonProperty("name")]
        public string Name { get; set; } 

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; } 

        [JsonProperty("country")]
        public string Country { get; set; } 
    }
}
