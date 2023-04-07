namespace MaplrSugarShack.Server.Core.Models.Records
{
	public sealed record ProductCartRecord
	{
		public ProductOrderRecord? Order { get; set; }
		public ProductRecord? Product { get; set; }
	}
}
