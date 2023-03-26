namespace CatalogDemo.Repositories;

public class InMemProductRepository : IRepository
{
    private readonly List<Product> Products = new()
    {
        new Product() { Id = Guid.NewGuid(), Name = "Book", Price = 100, Quantity = 10, Description = "Science book", CreatedDate = DateTimeOffset.UtcNow},
        new Product() { Id = Guid.NewGuid(), Name = "Rice", Price = 50, Quantity = 50, Description = "Basic grans", CreatedDate = DateTimeOffset.UtcNow},
        new Product() { Id = Guid.NewGuid(), Name = "Toy", Price=30, Quantity=30, Description = "Toy for childrens", CreatedDate = DateTimeOffset.UtcNow},
    };

    public void Create(Product product)
    {
        Products.Add(product);
    }

    public IEnumerable<Product> GetProducts()
    {
        return Products;
    }

    public Product GetById(Guid id)
    {
        var existingProduct = Products.SingleOrDefault(e => e.Id.Equals(id));

        if (existingProduct is null)
        {
            throw new ArgumentNullException($"This product {nameof(existingProduct)} not be found ");
        }

        return existingProduct;
    }

    public void Update(Guid id, Product product)
    {
        int index = Products.FindIndex(e => e.Id.Equals(id));
        Products[index] = product;
    }

    public void Delete(Guid id)
    {
        var product = GetById(id);
        Products.Remove(product);
    }
}