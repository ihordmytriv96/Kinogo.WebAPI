using Kinogo.WebAPI.Domain.Genre.Entities;
using Kinogo.WebAPI.Host.Common.Mapper.Contracts;
using Kinogo.WebAPI.Host.Genre.Models;

namespace Kinogo.WebAPI.Host.Genre.Mappers
{
    public class GenreModelMapper : IBaseMapper<GenreEntity, GenreModel>
    {
        public GenreModel Map(GenreEntity map)
            => new GenreModel()
            {
                Id = map.Id,
                Name = map.Name,
            };
    }
}
