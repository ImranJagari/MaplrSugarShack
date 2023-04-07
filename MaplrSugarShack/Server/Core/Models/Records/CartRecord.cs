namespace MaplrSugarShack.Server.Core.Models.Records
{
    public sealed record CartRecord : BaseRecord
    {
        public List<ProductOrderRecord> Products { get; set; } = new List<ProductOrderRecord>();
    }
}
