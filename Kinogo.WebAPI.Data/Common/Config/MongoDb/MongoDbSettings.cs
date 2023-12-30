using Kinogo.WebAPI.Data.Common.Config.MongoDb.Contracts;

namespace Kinogo.WebAPI.Data.Common.Config.MongoDb
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
