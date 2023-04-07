using MaplrSugarShack.Server.Core.Models.Records;
using MaplrSugarShack.Shared;

namespace MaplrSugarShack.Server.Core.Mappers
{
	public static class CartMapper
	{
		public static CartLineDto ToCartLineDto(this ProductCartRecord productOrder)
		{
			return new CartLineDto
			{
				Image = productOrder.Product?.ImageUrl.ToString() ?? string.Empty,
				Name = productOrder.Product?.Name ?? string.Empty,
				Price = productOrder.Product?.Price ?? 0,
				ProductId = productOrder.Order?.ProductId.ToString() ?? string.Empty,
				Qty = productOrder.Order?.Quantity ?? 0
			};
		}
	}
}
