using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models
{
    public class CustomerDetail
    {
        [Key]
        public Guid Id { get; set; } 
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public string? Job { get; set; }
        public bool? Gender { get; set; }

        public Byte[] RowVersion { get; set; }




    }
}
