using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ShopApi.Context;
using ShopApi.Dtos;
using ShopApi.Models;
using ShopApi.Repositories.Interfaces;

namespace ShopApi.Repositories.Implementations
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IMemoryCache _cache;
        private readonly ShopContext _db;
        private readonly ILogger<BrandRepository> _logger;

        public BrandRepository(ShopContext db, ILogger<BrandRepository> logger, IMemoryCache cache) 
        {
            _db=db;
            _logger=logger;
            _cache=cache;

        }

        public async Task addBrand(BrandDto brand)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
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

                await transaction.CommitAsync();

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Olmuş");
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Product> DeleteBrandsProduct(string brandName,string productName)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
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

                await transaction.CommitAsync();

                return Product;



            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Brand>> GetBrands()
        {
            try
            {
                var CacheKey = "Brands";
                if (_cache.TryGetValue(CacheKey,out List<Brand> CachedBrands))
                {
                    if (CachedBrands!=null)
                    {
                        return CachedBrands;
                    }
                }
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

                _cache.Set(CacheKey, Brands,TimeSpan.FromMinutes(60));
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
            using var transaction = await _db.Database.BeginTransactionAsync();
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
                await transaction.CommitAsync();
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata oluştu");
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateBrand(string Name, BrandDto brandDto)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                if (brandDto == null)
                {
                    _logger.LogError("İstenen Bilgileri Giriniz");
                    return;
                }

                var currentBrand = await _db.Brands.FirstOrDefaultAsync(b => b.Name == Name);

                if (currentBrand == null)
                {
                    _logger.LogError("İstenen Marka Bulunamadı Marka :" + Name);
                    return;
                }

                currentBrand.Name = brandDto.Name;
                currentBrand.Products = brandDto.Products.Select(p => new Product
                {
                    Name = p.Name,
                    price = p.price,
                    Title = p.Title,
                    Description = p.Description
                }).ToList();

                _db.Brands.Update(currentBrand);

                try
                {
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    _logger.LogError("Veri çakışması tespit edildi. Güncellenmiş veriyi alıp tekrar deneyin.");

                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Brand)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = await entry.GetDatabaseValuesAsync();

                            if (databaseValues == null)
                            {
                                _logger.LogError("Bu kayıt silinmiş. Güncelleme yapılamaz.");
                                throw new Exception("Bu marka başka biri tarafından silindi.");
                            }

                            // Kullanıcıya uyarı vermek için eski ve yeni değerleri kaydet
                            _logger.LogWarning("Eski Veri: {OldData} | Yeni Veri: {NewData}", databaseValues, proposedValues);

                            // Çakışma durumunda, veriyi en güncel haliyle güncelle
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                    }

                    throw new Exception("Veri başka bir kullanıcı tarafından değiştirildi. Lütfen tekrar deneyin.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu: " + ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }



    }
}
