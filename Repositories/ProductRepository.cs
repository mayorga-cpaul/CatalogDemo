namespace CatalogDemo.Repositories;

public class ProductRepository : IRepository
{
    private readonly IContext context;
    public ProductRepository(IContext context)
    {
        this.context = context;
    }
    public void Create(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var product = GetById(id);
        context.Products.Remove(product);
        context.SaveChanges();
    }

    public Product GetById(Guid id)
    {
        var existingProduct = context.Products.FirstOrDefault(e => e.Id.Equals(id));

        if (existingProduct is null)
        {
            throw new ArgumentNullException($"This product {nameof(existingProduct)} not be found ");
        }
        
        return existingProduct;
    }

    public IEnumerable<Product> GetProducts()
    {
        return context.Products;
    }

    public void Update(Guid id, Product product)
    {
        product.Id = id;
        context.Products.Update(product);
        context.SaveChanges();
    }
}