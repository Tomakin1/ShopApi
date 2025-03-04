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
        }
    }
}
