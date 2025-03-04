using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models;

namespace ShopApi.TypeConfigs
{
    public class CustomersBrandTypeConfig : IEntityTypeConfiguration<CustomersBrand>
    {
        public void Configure(EntityTypeBuilder<CustomersBrand> builder)
        {
            builder.Property(x=>x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()"); 
            builder.HasKey(cb => new { cb.CustomerId, cb.BrandId });

            
            builder.HasOne(cb => cb.Customer)
                .WithMany(c => c.CustomersBrands) 
                .HasForeignKey(cb => cb.CustomerId);

            
            builder.HasOne(cb => cb.Brand)
                .WithMany(b => b.CustomersBrands) 
                .HasForeignKey(cb => cb.BrandId);
        }
    }
}
