using Microsoft.EntityFrameworkCore;
using ShopApi.Context;
using ShopApi.Dtos;
using ShopApi.Models;
using ShopApi.Repositories.Interfaces;

namespace ShopApi.Repositories.Implementations
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ShopContext _db;
        private readonly ILogger<BrandRepository> _logger;

        public BrandRepository(ShopContext db, ILogger<BrandRepository> logger) 
        {
            _db=db;
            _logger=logger;

        }

        public async Task addBrand(BrandDto brand)
        {
            try
            {
                if (brand==null)
                {
                    _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                    return;
                }

                var newBrand = new Brand
                {
                    Id = Guid.NewGuid(),
                    Name = brand.Name,

                };
                  
                await _db.Brands.AddAsync(newBrand);
                await _db.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Olmuş");
                throw;
            }
        }

        public async Task removeBrand(string Name)
        {
            try
            {
                var DeletedBrand = await _db.Brands.FirstOrDefaultAsync(b=>b.Name == Name);

                if (DeletedBrand==null)
                {
                    _logger.LogError("İstenen Marka Bulunamadı Marka İsmi : "+Name);
                    return;
                }

                 _db.Brands.Remove(DeletedBrand);
                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata oluştu");
                throw;
            }
        }
    }
}
