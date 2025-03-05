using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopApi.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public int TCKN { get; set; }



        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public ICollection<CustomersBrand>? CustomersBrands { get; set; } = new List<CustomersBrand>();
        public CustomerDetail? CustomerDetail { get; set; }

}

    }

