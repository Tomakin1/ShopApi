using Microsoft.EntityFrameworkCore;
using ShopApi.Models;

namespace ShopApi.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
        public DbSet<CustomersBrand> CustomerBrands { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
        }
    }
}
