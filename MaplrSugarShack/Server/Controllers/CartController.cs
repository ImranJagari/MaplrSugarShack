using MaplrSugarShack.Server.Core.Mappers;
using MaplrSugarShack.Server.Services;
using MaplrSugarShack.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace MaplrSugarShack.Server.Controllers
{
	[Route("cart")]
	public sealed class CartController : Controller
	{
		private readonly CartService _cartService;

		public CartController(CartService cartService)
		{
			_cartService = cartService;
		}

		[HttpGet]
		public async Task<ICollection<CartLineDto>> GetCart()
		{
			return await Task.Run(() => _cartService.GetProducts().Select(CartMapper.ToCartLineDto).ToList()).ConfigureAwait(false);
		}

		[HttpPut]
		public Task AddToCart([FromQuery] string productId, [FromQuery] int quantity) 
		{
			return _cartService.AddOrUpdateProduct(ObjectId.Parse(productId), quantity, true);
		}

		[HttpPatch]
		public Task ChangeQty([FromQuery] string productId, [FromQuery] int newQty) 
		{
			return _cartService.AddOrUpdateProduct(ObjectId.Parse(productId), newQty, false);
		}

		[HttpDelete]
		public Task RemoveFromCart([FromQuery] string productId) 
		{
			return _cartService.RemoveProduct(ObjectId.Parse(productId));
		}
	}
}
