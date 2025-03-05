using ShopApi.Models;

namespace ShopApi.Dtos
{
    public class BrandDto
    {
        public string Name { get; set; } = default!;

        public List<Guid>? ProductsIds { get; set; } = new List<Guid>();
        public List<Guid>? CustomersBrandsIds { get; set; } = new List<Guid>();
    }
}
