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

        public async Task<Product> DeleteBrandsProduct(string brandName,string productName)
        {
            try
            {
                var Brand = await _db.Brands
                        .FirstOrDefaultAsync(b => b.Name == brandName);

                if (Brand==null)
                {
                    _logger.LogError("İstenen Marka Getirilirken Bir Hata Oluştu Marka : "+ brandName);
                    return null;
                }

                  var Product =Brand.Products.FirstOrDefault(p => p.Name == productName);

                if (Product==null)
                {
                    _logger.LogError("İstenen Marka Getirilirken Bir Hata Oluştu Marka : " + productName);
                    return null;
                }

                _db.Product.Remove(Product);
                await _db.SaveChangesAsync();

                return Product;



            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        public async Task<List<Brand>> GetBrands()
        {
            try
            {
                var Brands = await _db.Brands.AsNoTracking()
                            .Select(b => new Brand
                            {
                                Name=b.Name,
                                Products=b.Products,
                                CustomersBrands=b.CustomersBrands
                                
                            }).ToListAsync();

                if (!Brands.Any())
                {
                    _logger.LogError("Liste Getirilirken Bir Hata Oluştu");
                    return new List<Brand>();
                }

                return Brands;

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
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

        public async Task UpdateBrand(string Name, BrandDto brandDto)
        {

            try
            {

                if (brandDto==null)
                {
                    _logger.LogError("İstenen Bilgileri Giriniz");
                    return;
                }

                var CurrentBrand = await _db.Brands.FirstOrDefaultAsync(b=> b.Name==Name);

                if (CurrentBrand == null)
                {
                    _logger.LogError("İstenen Marka Bulunamadı Marka :"+Name);
                    return;
                }

                CurrentBrand.Name = brandDto.Name;   // Öğren
                CurrentBrand.Products = brandDto.Products.Select(p => new Product
                {
                    Name=p.Name,
                    price=p.price,
                    Title=p.Title,
                    Description=p.Description
                    

                }).ToList();

                _db.Brands.Update(CurrentBrand);
                await _db.SaveChangesAsync();



            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }


    }
}
