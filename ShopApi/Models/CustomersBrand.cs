namespace ShopApi.Models
{
    public class CustomersBrand
    {
        public Guid Id { get; set; } 

        public  Guid BrandId { get; set; }
        public Brand? Brand { get; set; }

        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }



    }
}
