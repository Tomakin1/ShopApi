using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models;

namespace ShopApi.TypeConfigs
{
    public class CustomerTypeConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c=>c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()"); 

            builder.HasMany(c=>c.Products).WithOne(p=>p.Customer).HasForeignKey(p=>p.CustomerId);

            builder.HasOne(c => c.CustomerDetail).WithOne(x => x.Customer).HasForeignKey<CustomerDetail>(x => x.CustomerId);

        }
    }
}
