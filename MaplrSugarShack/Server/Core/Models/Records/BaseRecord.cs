using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MaplrSugarShack.Server.Core.Models.Records
{
    public abstract record BaseRecord
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime LastModifiedTime { get; set; }
    }
}
