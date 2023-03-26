namespace CatalogDemo.Common;

public class Dtos
{
    public record ProductDto(Guid id, string Name, string Description, int Quantity, decimal price, DateTimeOffset CreatedDate);
    public record CreateProductDto(string Name, string Description, int Quantity, decimal price);
}