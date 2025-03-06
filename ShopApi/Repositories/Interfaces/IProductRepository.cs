using ShopApi.Dtos;
using ShopApi.Models;

namespace ShopApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddProduct(ProductDto product);
        Task DeleteProduct(string Name);
        Task UpdateProduct(string Name, ProductDto product);
        Task<List<ProductDto>> AllProducts();
        Task<ProductDto> ProductByName(string Name);
        Task<List<ProductDto>> ProductsBrands();
        Task IncrementProductsPrice(int Price); // BATCH İŞLEMİ


    }
}
