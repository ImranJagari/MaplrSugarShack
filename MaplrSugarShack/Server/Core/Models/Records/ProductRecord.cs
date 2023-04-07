using MaplrSugarShack.Server.Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MaplrSugarShack.Server.Core.Models.Records
{
    public sealed record ProductRecord : BaseRecord
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public double Price { get; set; }
        public ProductTypeEnum Type { get; set; }
    }
}
