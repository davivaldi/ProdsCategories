using Microsoft.EntityFrameworkCore;

namespace ProdsCategories.Models
{
    public class ProdCateContext: DbContext
    {
        public ProdCateContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Associations> Associations {get; set;}
    }
}