using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models;

namespace ShopApi.TypeConfigs
{
    public class BrandTypeConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b=>b.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()"); 

            builder.Property(b => b.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(b=>b.Products).WithOne(b => b.Brand).HasForeignKey(b => b.BrandId);
        }
    }
}
