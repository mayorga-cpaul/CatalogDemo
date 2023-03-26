using static CatalogDemo.Common.Dtos;

namespace CatalogDemo.Extensions
{
    public static class ProductExtension
    {
        public static ProductDto AsDto(this Product product)
        {
            return new ProductDto(product.Id, product.Name, product.Description, product.Quantity, product.Price, product.CreatedDate);
        }

        public static Product AsPoco(this CreateProductDto productDto)
        {
            return new Product()
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Description = productDto.Description, 
                Quantity = productDto.Quantity,
                Price = productDto.price,
                CreatedDate = DateTimeOffset.UtcNow,
            };
        }
    }
}