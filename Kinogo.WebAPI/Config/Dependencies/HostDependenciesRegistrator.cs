using Kinogo.WebAPI.Host.Genre.Dependencies;
using Kinogo.WebAPI.Host.Movie.Dependencies;

namespace Kinogo.WebAPI.Host.Config.Dependencies
{
    public static class HostDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            MovieDependenciesRegistrator.RegisterDependencies(services);
            GenreDependenciesRegistrator.RegisterDependencies(services);
        }
    }
}
