using ShopApi.Models;

namespace ShopApi.Dtos
{
    public class BrandDto
    {
        public string Name { get; set; } = default!;

        public List<ProductDto>? Products { get; set; } = new List<ProductDto>();
        public List<CustomersBrandDto>? CustomerBrands  { get; set; } = new List<CustomersBrandDto>();
    }
}
