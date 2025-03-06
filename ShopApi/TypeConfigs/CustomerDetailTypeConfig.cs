using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models;

namespace ShopApi.TypeConfigs
{
    public class CustomerDetailTypeConfig : IEntityTypeConfiguration<CustomerDetail>
    {
        public void Configure(EntityTypeBuilder<CustomerDetail> builder)
        {
            builder.Property(x=>x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            builder.Property(c => c.Address).HasMaxLength(1000).HasColumnType("nvarchar").IsRequired(false);
            builder.Property(c => c.Age).IsRequired(false);
            builder.Property(c => c.Job).HasMaxLength(40).HasColumnType("nvarchar").IsRequired(false);
            builder.Property(c => c.Gender).IsRequired(false).HasDefaultValue(true);


            //<-----------------------------------CHATGPT DATASEED KODLARI--------------------------------------------->
            builder.HasData(
                   new CustomerDetail
                   {
                       Id = Guid.Parse("b0a58b50-92ad-41ea-bcfb-b227d29d4b9d"),
                       CustomerId = Guid.Parse("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), // Ensure this exists in Customer table
                       Address = "İstanbul, Türkiye",
                       Age = 30,
                       Job = "Yazılımcı",
                       Gender = true
                   },
                   new CustomerDetail
                   {
                       Id = Guid.Parse("b3e4bb49-3810-41c6-bb69-29b017bb1f13"),
                       CustomerId = Guid.Parse("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"),
                       Address = "Ankara, Türkiye",
                       Age = 28,
                       Job = "Mühendis",
                       Gender = true
                   },
                   new CustomerDetail
                   {
                       Id = Guid.Parse("c6a5478e-68f6-442b-9be6-3bafced1dbd6"),
                       CustomerId = Guid.Parse("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"),
                       Address = "İzmir, Türkiye",
                       Age = 25,
                       Job = "Öğrenci",
                       Gender = false
                   },
                   new CustomerDetail
                   {
                       Id = Guid.Parse("d93d0776-6d0c-44b4-b7e0-15b5d3b90a58"),
                       CustomerId = Guid.Parse("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"),
                       Address = "Bursa, Türkiye",
                       Age = 35,
                       Job = "Doktor",
                       Gender = true
                   },
                   new CustomerDetail
                   {
                       Id = Guid.Parse("e476b789-02f0-431e-8f88-8b0c358b29e1"),
                       CustomerId = Guid.Parse("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"),
                       Address = "Antalya, Türkiye",
                       Age = 40,
                       Job = "Avukat",
                       Gender = false
                   },
                   new CustomerDetail
                   {
                       Id = Guid.Parse("f9b0e460-7425-4b79-a94c-6659fdcb373b"),
                       CustomerId = Guid.Parse("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                       Address = "Eskişehir, Türkiye",
                       Age = 32,
                       Job = "İşletmeci",
                       Gender = true
                   }
            );
        }
    }
}
