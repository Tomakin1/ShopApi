using ShopApi.Models;

namespace ShopApi.Dtos
{
    public class CustomersBrandDto
    {
        public Guid BrandId { get; set; }
        public Brand? Brand { get; set; }

        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
