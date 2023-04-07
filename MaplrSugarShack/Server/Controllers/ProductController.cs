using MaplrSugarShack.Server.Core.Enums;
using MaplrSugarShack.Server.Core.Mappers;
using MaplrSugarShack.Server.Services;
using MaplrSugarShack.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Type = MaplrSugarShack.Shared.Type;

namespace MaplrSugarShack.Server.Controllers
{
    [Route("/products")]
    public sealed class ProductController
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService) 
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ICollection<CatalogueItemDto>> GetCatalogue([FromQuery] Type? type)
        {
            return await Task.Run(() => _productService.GetProductsByType((ProductTypeEnum?)type).Select(ProductMapper.ToCatalogueItemDto).ToList());
        }

        [HttpGet("{productId}")]
        public async Task<MapleSyrupDto> GetProductInfo(string productId)
        {
            return await Task.Run(() => _productService.GetProductById(ObjectId.Parse(productId)).ToMapleSyrupDto());
        }
    }
}
