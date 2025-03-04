using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models;

namespace ShopApi.TypeConfigs
{
    public class ProductTypeConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(30);
        }
    }
}
