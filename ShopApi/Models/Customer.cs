using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopApi.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [JsonPropertyName("firstName")]
        [Required]
        public string FirstName { get; set; } = default!;
        [JsonPropertyName("lastName")]
        [Required]
        public string LastName { get; set; } = default!;
        [JsonPropertyName("email")]
        [Required]
        public string Email { get; set; } = default!;
        public int TCKN { get; set; }



        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public ICollection<CustomersBrand>? CustomersBrands { get; set; } = new List<CustomersBrand>();

        public CustomerDetail? CustomerDetail { get; set; }

}

    }

