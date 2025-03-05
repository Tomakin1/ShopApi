using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopApi.Models
{
    public class Brand
    {
        [Key]
        public Guid Id { get; set; } 
        public string Name { get; set; } = default!;

        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public ICollection<CustomersBrand>? CustomersBrands { get; set; } = new List<CustomersBrand>();




    }
}
