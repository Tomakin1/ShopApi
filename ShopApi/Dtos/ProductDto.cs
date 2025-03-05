using System.ComponentModel.DataAnnotations;

namespace ShopApi.Dtos
{
    public class ProductDto
    {
        public Guid BrandId { get; set; }
        public Guid CustomerId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!; // Ürün Açıklaması
        public string Title { get; set; } = default!; // Ürün Başlığı
        public int price { get; set; }

        public BrandDto? Brands { get; set; }
    }
}
