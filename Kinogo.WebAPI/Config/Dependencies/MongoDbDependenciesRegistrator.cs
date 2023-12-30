using Kinogo.WebAPI.Data.Common.Config.MongoDb;
using Kinogo.WebAPI.Data.Common.Config.MongoDb.Contracts;
using Microsoft.Extensions.Options;

namespace Kinogo.WebAPI.Host.Config.Dependencies
{
    public static class MongoDbDependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            services.Configure<MongoDbSettings>(((IConfiguration)provider.GetService(typeof(IConfiguration))).GetSection("KinogoDatabase"));
            services.AddTransient<IMongoDbSettings>(serviceProvider => 
                            serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }
    }
}
