using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ShopApi.Context;
using ShopApi.Dtos;
using ShopApi.Models;
using ShopApi.Repositories.Interfaces;
using System.Transactions;

namespace ShopApi.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMemoryCache _cache;
        private readonly ShopContext _db;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ShopContext db, ILogger<ProductRepository> logger, IMemoryCache cache)
        {
            _db = db;
            _logger = logger;
            _cache = cache;
        }

        public async Task AddProduct(ProductDto Dto)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                if (Dto == null)
                {
                    _logger.LogError("Bilgileri Giriniz");
                    return;
                }

                var NewProduct = new Product
                {
                    Name = Dto.Name,
                    Title = Dto.Title,
                    CustomerId = Dto.CustomerId,
                    BrandId = Dto.BrandId,
                    Description = Dto.Description,
                    price = Dto.price  
                };

                await _db.Product.AddAsync(NewProduct);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<ProductDto>> AllProducts()
        {
            try
            {
                var CacheKey = "AllProduct";
                if (_cache.TryGetValue(CacheKey,out List<ProductDto> CachedProduct))
                {
                    if (CachedProduct!=null)
                    {
                        return CachedProduct;
                    }
                }
                var ProductList = await _db.Product.AsNoTracking()
                        .Select(p => new ProductDto
                        {
                           
                            Name=p.Name,
                            Description=p.Description,
                            CustomerId= p.CustomerId,
                            price = p.price,
                            Title = p.Title,
                            BrandId = p.BrandId
                            
                            
                        }).ToListAsync();

                if (!ProductList.Any())
                {
                    _logger.LogError("Ürün Listesi Getirilirken Bir Hata Oluştu , Boş OLABİLİR");
                    return new List<ProductDto>();
                }

                _cache.Set(CacheKey, ProductList,TimeSpan.FromMinutes(60));
                return ProductList;
            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        public async Task DeleteProduct(string Name)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {

                var DeletedProduct = await _db.Product.FirstOrDefaultAsync(p => p.Name == Name);

                if (DeletedProduct==null)
                {
                    _logger.LogError("Kullanıcı Bulunamadı");
                }
                else
                {
                    _db.Product.Remove(DeletedProduct);
                    await _db.SaveChangesAsync();
                }

                await transaction.CommitAsync();



            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                await transaction.RollbackAsync();
                throw;
            }
        }


        //--------------------GPT KODU ÖĞREN---------------
        public async Task IncrementProductsPrice(int price)
        {
            try
            {
                await _db.Product
                    .Where(p => p.price < price)
                    .ExecuteUpdateAsync(setters => setters.SetProperty(p => p.price, p => p.price + 10));  // BATCH İŞLEMİ (birden fazla işlemin topluca yapılması)

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        public async Task<List<ProductDto>> OrderProductsByPrice(int price) // ORDER BY
        {
            try
            {
                var Prices = await _db.Product.AsNoTracking()
                        .Where(p => p.price < price)
                        .OrderBy(p=>p.price)
                        .Select(p=> new ProductDto
                        {
                            Name=p.Name,
                            Title=p.Title,
                            Description=p.Description,
                            price = p.price
                            
                        })
                        .ToListAsync();

                if (!Prices.Any())
                {
                    _logger.LogError("Liste Getirilirken Bir Hata Oluştu");
                    return new List<ProductDto>();
                }

                return Prices;


            }
            catch (Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata Oluştu"+ex.Message);
                throw;
            }
        }

        public async Task<ProductDto> ProductByName(string Name)
        {

            try
            {
                var CacheKey = $"Product_{Name}";
                if (_cache.TryGetValue(CacheKey, out ProductDto CachedProduct))
                {
                    if (CachedProduct != null)
                    {
                        return CachedProduct;
                    }
                }
                var Product = await _db.Product.AsNoTracking()
                    .Where(p => p.Name == Name)
                    .Select(p => new ProductDto
                    {
                        Name = p.Name,
                        Title = p.Title,
                        Description = p.Description,
                        price = p.price,
                        CustomerId = p.CustomerId
                    }).FirstOrDefaultAsync();

                if (Product == null)
                {
                    _logger.LogError("Ürün Bulunamadı Ürün Adı : "+Name);
                    return null;
                }

                _cache.Set(CacheKey, Product,TimeSpan.FromMinutes(60));
                return Product;

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }

        }

        public async Task<List<ProductDto>> ProductsBrands()
        {
            try
            {
                var CacheKey = "ProductsBrands";
                if (_cache.TryGetValue(CacheKey, out List<ProductDto> CachedProduct))
                {
                    if (CachedProduct != null)
                    {
                        return CachedProduct;
                    }
                }
                var ProductsBrand = await _db.Product.AsNoTracking()
                        .Include(p => p.Brand)
                        .Select(p => new ProductDto
                        {
                             Name=p.Name,
                             Title=p.Title,
                             Description=p.Description,
                             price=p.price,
                             Brands=new BrandDto
                             {
                                 Name=p.Brand.Name
                             }
                             
                        }).ToListAsync();

                if (!ProductsBrand.Any())
                {
                    _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                    return new List<ProductDto>();
                }

                _cache.Set(CacheKey , ProductsBrand, TimeSpan.FromMinutes(60));
                return ProductsBrand;

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        public async Task UpdateProduct(string Name, ProductDto product)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                if (product == null)
                {
                    _logger.LogError("İstenen Bilgileri Giriniz");
                    return;
                }

                var CurrentProduct = await _db.Product.FirstOrDefaultAsync(p => p.Name == Name);

                if (CurrentProduct == null)
                {
                    _logger.LogError("Ürün Bulunamadı Ürün : " + Name);
                    return;
                }

                CurrentProduct.Name = product.Name;
                CurrentProduct.Title = product.Title;
                CurrentProduct.Description = product.Description;
                CurrentProduct.price = product.price;

                _db.Product.Update(CurrentProduct);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();

            }
            catch(Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata Oluştu");
                await transaction.RollbackAsync();
                throw;
            }
            
            
        }
    }
}
