using MaplrSugarShack.Server.Core.Models.Records;
using MaplrSugarShack.Shared;

namespace MaplrSugarShack.Server.Core.Mappers
{
    public static class ProductMapper
    {
        public static CatalogueItemDto ToCatalogueItemDto(this ProductRecord product)
        {
            return new CatalogueItemDto
            {
                Id = product.Id.ToString(),
                Image = product.ImageUrl,
                MaxQty = product.Quantity,
                Name = product.Name,
                Price = product.Price,
                Type = (CatalogueItemDtoType)product.Type
            };
        }

        public static MapleSyrupDto ToMapleSyrupDto(this ProductRecord? product)
        {
            if (product == null)
                return new MapleSyrupDto
                {
                    Id = string.Empty,
                    Name = string.Empty,
                    Description = string.Empty,
                    Image = string.Empty,
                    Stock = 0,
                    Price = 0,
                    Type = MapleSyrupDtoType.AMBER
                };

            return new MapleSyrupDto
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description,
                Image = product.ImageUrl,
                Stock = product.Quantity,
                Price = product.Price,
                Type = (MapleSyrupDtoType)product.Type
            };
        }
    }
}
