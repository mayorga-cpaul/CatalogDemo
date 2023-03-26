using Microsoft.EntityFrameworkCore;

namespace CatalogDemo.Data;

public class CatalogDemoDbContext : DbContext, IContext
{
    public CatalogDemoDbContext()
    {

    }

    public CatalogDemoDbContext(DbContextOptions<CatalogDemoDbContext> options)
     : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}