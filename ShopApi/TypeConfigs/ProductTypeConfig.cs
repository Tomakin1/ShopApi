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
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500).HasColumnType("nvarchar");
            builder.Property(p => p.Title).IsRequired().HasMaxLength(30).HasColumnType("nvarchar");

            builder.Property(p=>p.RowVersion).IsRowVersion();

            builder.HasIndex(u => u.Name)
                .HasDatabaseName("Index_ProductName") // Index
                .IsUnique(false);

            builder.HasOne(p => p.Brand)
                   .WithMany(b => b.Products)
                   .HasForeignKey(p => p.BrandId)
                   .OnDelete(DeleteBehavior.Restrict); // Dış anahtar için ilişki kurma


            //<-----------------------------------CHATGPT DATASEED KODLARI--------------------------------------------->
            builder.HasData(
                new Product
                {
                    Id = Guid.Parse("a3f3a3f3-1f1f-4f1f-b1f1-8dbdd24dbd9c"),
                    Name = "iPhone 13",
                    Description = "Apple's latest smartphone with a powerful A15 chip.",
                    Title = "Smartphone",
                    price = 999,
                    BrandId = Guid.Parse("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), // Apple
                    CustomerId = Guid.Parse("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c") // CustomerId: Ömer Tomakin
                },
                new Product
                {
                    Id = Guid.Parse("b4f4b4f4-2f2f-4f2f-b2f2-9dbdd25dcf9d"),
                    Name = "Samsung Galaxy S21",
                    Description = "Samsung's flagship phone with advanced camera features.",
                    Title = "Smartphone",
                    price = 899,
                    BrandId = Guid.Parse("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"), // Samsung
                    CustomerId = Guid.Parse("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d") // CustomerId: Ali Yılmaz
                },
                new Product
                {
                    Id = Guid.Parse("c5f5c5f5-3f3f-5f3f-c3f3-0dbdd26dcf9e"),
                    Name = "Sony WH-1000XM4",
                    Description = "Sony's noise-canceling wireless headphones.",
                    Title = "Headphones",
                    price = 350,
                    BrandId = Guid.Parse("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"), // Sony
                    CustomerId = Guid.Parse("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e") // CustomerId: Ayşe Kara
                },
                new Product
                {
                    Id = Guid.Parse("d6f6d6f6-4f4f-6f4f-d4f4-1dbdd27ddf9f"),
                    Name = "LG OLED TV",
                    Description = "LG's 55-inch OLED television with stunning picture quality.",
                    Title = "Television",
                    price = 1200,
                    BrandId = Guid.Parse("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"), // LG
                    CustomerId = Guid.Parse("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f") // CustomerId: Murat Demir
                },
                new Product
                {
                    Id = Guid.Parse("e7f7e7f7-5f5f-7f5f-e5f5-2dbdd28eea9f"),
                    Name = "Huawei MateBook X Pro",
                    Description = "Huawei's premium laptop with a sleek design and powerful performance.",
                    Title = "Laptop",
                    price = 1500,
                    BrandId = Guid.Parse("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f"), // Huawei
                    CustomerId = Guid.Parse("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f") // CustomerId: Fatma Öztürk
                },
                new Product
                {
                    Id = Guid.Parse("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                    Name = "Xiaomi Mi Band 6",
                    Description = "Xiaomi's fitness tracker with a full-screen AMOLED display.",
                    Title = "Fitness Tracker",
                    price = 50,
                    BrandId = Guid.Parse("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), // Xiaomi
                    CustomerId = Guid.Parse("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f") // CustomerId: Mehmet Çelik
                }
            );
        }
    }
}
