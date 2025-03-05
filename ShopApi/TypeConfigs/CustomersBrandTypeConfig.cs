using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models;

namespace ShopApi.TypeConfigs
{
    public class CustomersBrandTypeConfig : IEntityTypeConfiguration<CustomersBrand>
    {
        public void Configure(EntityTypeBuilder<CustomersBrand> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            builder.HasKey(cb => new { cb.CustomerId, cb.BrandId });

            builder.HasOne(cb => cb.Customer)
                .WithMany(c => c.CustomersBrands)
                .HasForeignKey(cb => cb.CustomerId);

            builder.HasOne(cb => cb.Brand)
                .WithMany(b => b.CustomersBrands)
                .HasForeignKey(cb => cb.BrandId);

            // Seed Data for CustomersBrand
            builder.HasData(
                new CustomersBrand
                {
                    CustomerId = Guid.Parse("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), // Ömer Tomakin
                    BrandId = Guid.Parse("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c")  // Apple
                },
                new CustomersBrand
                {
                    CustomerId = Guid.Parse("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"), // Ali Yılmaz
                    BrandId = Guid.Parse("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d")  // Samsung
                },
                new CustomersBrand
                {
                    CustomerId = Guid.Parse("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"), // Ayşe Kara
                    BrandId = Guid.Parse("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e")  // Sony
                },
                new CustomersBrand
                {
                    CustomerId = Guid.Parse("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"), // Murat Demir
                    BrandId = Guid.Parse("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f")  // LG
                },
                new CustomersBrand
                {
                    CustomerId = Guid.Parse("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"), // Fatma Öztürk
                    BrandId = Guid.Parse("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f")  // Huawei
                },
                new CustomersBrand
                {
                    CustomerId = Guid.Parse("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), // Mehmet Çelik
                    BrandId = Guid.Parse("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f")  // Xiaomi
                }
            );
        }
    }
}
