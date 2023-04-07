using MaplrSugarShack.Server.Core.Models.Records;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MaplrSugarShack.Server.Services
{
	public sealed class CartService
	{
		private const string CollectionName = "cart";
		private readonly IMongoCollection<ProductOrderRecord> _collection;
		private readonly ProductService _productService;

		public CartService(MongoService mongoService, ProductService productService)
		{
			_collection = mongoService.Database.GetCollection<ProductOrderRecord>(CollectionName);
			_productService = productService;
		}

		public ICollection<ProductCartRecord> GetProducts()
		{
			var productOrders = _collection.AsQueryable().ToList();
			return productOrders.Select(_ => new ProductCartRecord
			{
				Order = _,
				Product = _productService.GetProductById(_.ProductId),
			}).ToList();
		}

		public async Task AddOrUpdateProduct(ObjectId productId, int quantity, bool isAdding = false)
		{
			var cartProduct = _collection.AsQueryable().FirstOrDefault(_ => _.ProductId == productId);
			if (cartProduct is null)
			{
				await _collection.InsertOneAsync(new ProductOrderRecord
				{
					ProductId = productId,
					Quantity = quantity
				});
				return;
			}

			if (isAdding)
				cartProduct.Quantity += quantity;
			else
				cartProduct.Quantity = quantity;

			FilterDefinitionBuilder<ProductOrderRecord> eqfilter = Builders<ProductOrderRecord>.Filter;
			FilterDefinition<ProductOrderRecord> eqFilterDefinition = eqfilter.Eq(_ => _.Id, cartProduct.Id);

			await _collection.ReplaceOneAsync(eqFilterDefinition, cartProduct);
		}

		public async Task RemoveProduct(ObjectId productId)
		{
			await _collection.DeleteOneAsync(_ => _.ProductId == productId);
		}

		public async Task ClearAsync()
		{
            await _collection.DeleteManyAsync(_ => true);
        }
    }
}
