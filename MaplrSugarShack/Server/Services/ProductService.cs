using MaplrSugarShack.Server.Core.Enums;
using MaplrSugarShack.Server.Core.Models.Records;
using MaplrSugarShack.Shared;
using MongoDB.Bson;
using MongoDB.Driver;
using Type = MaplrSugarShack.Shared.Type;

namespace MaplrSugarShack.Server.Services
{
    public sealed class ProductService
	{
		private const string CollectionName = "products";
		private readonly IMongoCollection<ProductRecord> _collection;

		public ProductService(MongoService mongoService)
		{
			_collection = mongoService.Database.GetCollection<ProductRecord>(CollectionName);

        }

		public ICollection<ProductRecord> GetProductsByType(ProductTypeEnum? productType)
		{
            IQueryable<ProductRecord> query = _collection.AsQueryable();

			if (productType is not null)
				query = query.Where(_ => _.Type == productType);

            return query.ToList();
		}

		public ProductRecord? GetProductById(ObjectId productId)
		{
			return _collection.AsQueryable()
					.FirstOrDefault(_ => _.Id == productId);
		}

		public async Task UpdateAsync(ProductRecord record)
		{
            FilterDefinitionBuilder<ProductRecord> eqfilter = Builders<ProductRecord>.Filter;
            FilterDefinition<ProductRecord> eqFilterDefinition = eqfilter.Eq(_ => _.Id, record.Id);

            await _collection.ReplaceOneAsync(eqFilterDefinition, record);
		}
	}
}
