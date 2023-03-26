using System.ComponentModel.DataAnnotations;

namespace CatalogDemo.Common;

public class Dtos
{
    // Inmutables
    public record ProductDto(Guid id,[Required] string Name, string Description, [Range(1, 1000)]int Quantity,[Range(1, 1000)] decimal Price, DateTimeOffset CreatedDate);
    public record CreateProductDto([Required]string Name, string Description,[Range(1, 1000)] int Quantity,[Range(1, 1000)] decimal Price);
    public record UpdateProductDto([Required]string Name, string Description,[Range(1, 1000)] int Quantity,[Range(1, 1000)] decimal Price);

}