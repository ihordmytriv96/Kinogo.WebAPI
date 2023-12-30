using Kinogo.WebAPI.Data.Genre.Dependencies;
using Kinogo.WebAPI.Data.Movie.Dependencies;
using Kinogo.WebAPI.Data.RefreshToken.Dependencies;
using Kinogo.WebAPI.Data.User.Dependencies;
using Kinogo.WebAPI.Data.Utilities.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Kinogo.WebAPI.Data.Common.Dependencies
{
    public static class DataDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            MovieDependenciesRegistrator.RegisterDependencies(services);
            GenreDependenciesRegistrator.RegisterDependencies(services);
            PredicateBuilderDependenciesRegistrator.RegisterDependencies(services);
            UserDependenciesRegistrator.RegisterDependencies(services);
            RefreshTokenDependenciesRegistrator.RegisterDependencies(services);
        }
    }
}
