namespace Kinogo.WebAPI.Data.Movie.Filter.Contracts
{
    public interface IMovieFilterModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }

    }
}
