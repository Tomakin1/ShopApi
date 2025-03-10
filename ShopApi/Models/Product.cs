using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } 
        public Guid BrandId { get; set; }
        public Guid CustomerId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!; // Ürün Açıklaması
        public string Title { get; set; } = default!; // Ürün Başlığı
        public int price { get; set; }


        public Brand? Brand { get; set; }
        public Customer? Customer { get; set; }

        public Byte[] RowVersion { get; set; }
    }  
}
