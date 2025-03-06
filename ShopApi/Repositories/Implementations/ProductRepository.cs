using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShopApi.Context;
using ShopApi.Dtos;
using ShopApi.Models;
using ShopApi.Repositories.Interfaces;

namespace ShopApi.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _db;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ShopContext db, ILogger<ProductRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task AddProduct(ProductDto Dto)
        {
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

            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        public async Task<List<ProductDto>> AllProducts()
        {
            try
            {
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



            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
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

        public async Task<ProductDto> ProductByName(string Name)
        {

            try
            {
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
            if (product==null)
            {
                _logger.LogError("İstenen Bilgileri Giriniz");
                return;
            }

            var CurrentProduct = await _db.Product.FirstOrDefaultAsync(p=>p.Name==Name);

            if (CurrentProduct==null)
            {
                _logger.LogError("Ürün Bulunamadı Ürün : "+Name);
                return;
            }

            CurrentProduct.Name = product.Name;
            CurrentProduct.Title = product.Title;
            CurrentProduct.Description = product.Description;
            CurrentProduct.price = product.price;

            _db.Product.Update(CurrentProduct);
            await _db.SaveChangesAsync();
        }
    }
}
