using Microsoft.EntityFrameworkCore;

namespace CatalogDemo.Interface
{
    public interface IContext
    {
        public DbSet<Product> Products { get; set; }
        int SaveChanges();
    }
}