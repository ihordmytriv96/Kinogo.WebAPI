using Kinogo.WebAPI.Domain.Common.Entities.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kinogo.WebAPI.Domain.Common.Entities
{
    public class BaseEntity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
