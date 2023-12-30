using Kinogo.WebAPI.Domain.Genre.Entities;
using Kinogo.WebAPI.Host.Common.Mapper.Contracts;
using Kinogo.WebAPI.Host.Genre.Mappers;
using Kinogo.WebAPI.Host.Genre.Models;

namespace Kinogo.WebAPI.Host.Genre.Dependencies
{
    public static class GenreDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IBaseMapper<GenreEntity, GenreModel>, GenreModelMapper>();
        }
    }
}
