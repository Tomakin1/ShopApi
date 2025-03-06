using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models;

namespace ShopApi.TypeConfigs
{
    public class BrandTypeConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            builder.Property(b => b.Name).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");

            builder.HasMany(b => b.Products)
                   .WithOne(p => p.Brand)
                   .HasForeignKey(p => p.BrandId)
                   .OnDelete(DeleteBehavior.Restrict); // Dış anahtar ilişki

            builder.HasIndex(b => b.Name)
                .HasDatabaseName("Index_BrandName") // Index
                .IsUnique(false);



            //<-----------------------------------CHATGPT DATASEED KODLARI--------------------------------------------->

            builder.HasData(
                new Brand
                {
                    Id = Guid.Parse("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"),  // Apple
                    Name = "Apple"
                },
                new Brand
                {
                    Id = Guid.Parse("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"),  // Samsung
                    Name = "Samsung"
                },
                new Brand
                {
                    Id = Guid.Parse("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"),  // Sony
                    Name = "Sony"
                },
                new Brand
                {
                    Id = Guid.Parse("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"),  // LG
                    Name = "LG"
                },
                new Brand
                {
                    Id = Guid.Parse("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f"),  // Huawei
                    Name = "Huawei"
                },
                new Brand
                {
                    Id = Guid.Parse("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),  // Xiaomi
                    Name = "Xiaomi"
                }
            );
        }
    }
}
