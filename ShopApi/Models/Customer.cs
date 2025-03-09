using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopApi.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = default!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = default!;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = default!;

        [Required]
        public int TCKN { get; set; }

        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public ICollection<CustomersBrand>? CustomersBrands { get; set; } = new List<CustomersBrand>();
        public CustomerDetail? CustomerDetail { get; set; }

        public Byte[] RowVersion { get; set; }

    }

    }

