using MongoDB.Bson;

namespace MaplrSugarShack.Server.Core.Models.Records
{
	public sealed record ProductOrderRecord : BaseRecord
	{
		public ObjectId ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
