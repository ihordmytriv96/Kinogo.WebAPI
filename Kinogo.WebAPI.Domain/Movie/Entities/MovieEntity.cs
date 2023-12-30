using Kinogo.WebAPI.Domain.Common.Entities;

namespace Kinogo.WebAPI.Domain.Movie.Entities
{
    public class MovieEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathToMovie { get; set; }
        public int CreationYear { get; set; }
        public string PathToMovieLogo { get; set; }
        public List<string> MovieGenresIds { get; set; }
        public List<string> MovieMainActors { get; set; } 
        public List<string> MovieProducers { get; set; } 
        public string Country { get; set; }
    }
}
