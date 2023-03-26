namespace CatalogDemo.Interface;

public interface IRepository
{
    void Create(Product product);
    IEnumerable<Product> GetProducts();
    Product GetById(Guid id);
    void Update(Guid id, Product product);
    void Delete(Guid id);
}