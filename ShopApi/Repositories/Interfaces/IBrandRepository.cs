using ShopApi.Dtos;

namespace ShopApi.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task addBrand(BrandDto brand);
        Task removeBrand(string Name);
    }
}
