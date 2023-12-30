using Kinogo.WebAPI.Data.Movie.Filter.Contracts;
using Kinogo.WebAPI.Data.Utilities.Contracts;
using Kinogo.WebAPI.Domain.Common.Contracts.Filter;
using Kinogo.WebAPI.Domain.Movie.Entities;
using System.Linq.Expressions;

namespace Kinogo.WebAPI.Data.Movie.Filter
{
    public class MovieFilter : IEntityFilter<MovieEntity, IMovieFilterModel>
    {
        private readonly IPredicateBuilder _predicateBuilder;

        public MovieFilter(IPredicateBuilder predicateBuilder)
        {
            _predicateBuilder = predicateBuilder;
        }

        public Expression<Func<MovieEntity, bool>> Filter(IMovieFilterModel model)
        {
            if (model == null)
            {
                throw new ArgumentException("model");
            }

            var result = _predicateBuilder.True<MovieEntity>();

            if (!string.IsNullOrEmpty(model.Name))
            {
                result = _predicateBuilder.And(result, x => x.Name.ToLower().Contains(model.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.Country))
            {
                result = _predicateBuilder.And(result, x => x.Country.ToLower().Contains(model.Country.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.Genre))
            {
                result = _predicateBuilder.And(result, x => x.Country.ToLower().Contains(model.Genre.ToLower()));
            }

            if (model.Year != 0)
            {
                result = _predicateBuilder.And(result, x => x.CreationYear == model.Year);
            }

            return result;
        }
    }
}
