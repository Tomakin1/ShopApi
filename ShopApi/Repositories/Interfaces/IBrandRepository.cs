using ShopApi.Dtos;
using ShopApi.Models;

namespace ShopApi.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task addBrand(BrandDto brand);
        Task removeBrand(string Name);
        Task UpdateBrand(string Name, BrandDto brandDto);
        Task<List<Brand>> GetBrands();
        Task<Product> DeleteBrandsProduct(string brandName,string productName); // Seçilen brande bağlı seçilen brandı sil
    }
}
