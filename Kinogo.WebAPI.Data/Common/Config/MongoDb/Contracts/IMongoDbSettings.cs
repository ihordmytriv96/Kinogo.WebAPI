namespace Kinogo.WebAPI.Data.Common.Config.MongoDb.Contracts
{
    public interface IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
