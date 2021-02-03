using DataServices.Models;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base()
        {

        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
