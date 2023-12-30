using Kinogo.WebAPI.Data.Utilities.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Kinogo.WebAPI.Data.Utilities.Dependencies
{
    public static class PredicateBuilderDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IPredicateBuilder, PredicateBuilder>();
        }
    }
}
