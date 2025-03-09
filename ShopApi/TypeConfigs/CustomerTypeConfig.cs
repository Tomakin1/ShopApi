using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models;

namespace ShopApi.TypeConfigs
{
    public class CustomerTypeConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
                    builder.Property(c => c.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()"); 

                    builder.HasMany(c => c.Products).WithOne(p => p.Customer).HasForeignKey(p => p.CustomerId);

                    builder.Property(c => c.RowVersion).IsRowVersion();

                    builder.HasIndex(u => u.LastName)
                        .HasDatabaseName("Index_CustomerLastName")   // Index
                        .IsUnique(false);

                    builder.HasOne(c => c.CustomerDetail).WithOne(x => x.Customer).HasForeignKey<CustomerDetail>(x => x.CustomerId);

                    builder.Property(c => c.FirstName).HasColumnType("nvarchar");
                    builder.Property(c => c.LastName).HasColumnType("nvarchar");
                    builder.Property(c => c.Email).HasColumnType("nvarchar");


            //<-----------------------------------CHATGPT DATASEED KODLARI--------------------------------------------->

            builder.HasData(
                        new Customer
                        {
                            Id = Guid.Parse("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"),
                            FirstName = "Ömer",
                            LastName = "Tomakin",
                            Email = "tomakintomakin05@gmail.com",
                            TCKN = 231
                        },
                        new Customer
                        {
                            Id = Guid.Parse("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"),
                            FirstName = "Ali",
                            LastName = "Yılmaz",
                            Email = "ali.yilmaz@example.com",
                            TCKN = 234
                        },
                        new Customer
                        {
                            Id = Guid.Parse("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"),
                            FirstName = "Ayşe",
                            LastName = "Kara",
                            Email = "ayse.kara@example.com",
                            TCKN = 235
                        },
                        new Customer
                        {
                            Id = Guid.Parse("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"),
                            FirstName = "Murat",
                            LastName = "Demir",
                            Email = "murat.demir@example.com",
                            TCKN = 236
                        },
                        new Customer
                        {
                            Id = Guid.Parse("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"),
                            FirstName = "Fatma",
                            LastName = "Öztürk",
                            Email = "fatma.ozturk@example.com",
                            TCKN = 237
                        },
                        new Customer
                        {
                            Id = Guid.Parse("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                            FirstName = "Mehmet",
                            LastName = "Çelik",
                            Email = "mehmet.celik@example.com",
                            TCKN = 238
                        }
            );
        }
    }
}
