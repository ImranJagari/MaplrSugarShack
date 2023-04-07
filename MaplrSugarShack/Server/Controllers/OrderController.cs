using MaplrSugarShack.Server.Core.Helpers;
using MaplrSugarShack.Server.Services;
using MaplrSugarShack.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace MaplrSugarShack.Server.Controllers
{
    [Route("/order")]
    public sealed class OrderController : Controller
    {
        private readonly CartService _cartService;
        private readonly ProductService _productService;

        public OrderController(CartService cartService, ProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        [HttpPost]
        public async Task<OrderValidationResponseDto> PlaceOrder([FromBody] IEnumerable<OrderLineDto> orders)
        {
            IList<string> errors = new List<string>();
            await _cartService.ClearAsync().ConfigureAwait(false);
            foreach (var line in orders)
            {
                var product = _productService.GetProductById(ObjectId.Parse(line.ProductId));
                
                if (product is null)
                {
                    errors.Add($"the product ({line.ProductId}) is not valid !");
                    continue;
                }
                
                if (product.Quantity < line.Qty)
                {
                    errors.Add($"the product ({product.Name}) has not enough stock !");
                    continue;
                }

                product.Quantity -= line.Qty;
                await _productService.UpdateAsync(product).ConfigureAwait(false);
            }

            return OrderHelper.GetValidation(errors.ToArray());
        }
    }
}
