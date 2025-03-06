using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Context;
using ShopApi.Dtos;
using ShopApi.Models;
using ShopApi.Repositories.Interfaces;

namespace ShopApi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly ILogger<ProductController> _logger;
        private readonly ShopContext _db;

        public ProductController(IProductRepository repo, ILogger<ProductController> logger, ShopContext db)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]ProductDto product)
        {
            try
            {
                if (product==null)
                {
                    _logger.LogError("İstenen Bilgileri Giriniz");
                    return null;
                }

                await _repo.AddProduct(product);
                return StatusCode(201,"Ürün Eklendi");
            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu"+ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            try
            {
                var ProductList = await _repo.AllProducts();

                if (!ProductList.Any())
                {
                    _logger.LogError("Liste Getirilirken Bir Hata Meydana Geldi ");
                    return null;
                }

                return Ok(ProductList);
            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu"+ex.Message);
                throw;
            }

        }

        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteProduct(string Name)
        {
            try
            {
                var DeletedProduct =await _db.Product.FirstOrDefaultAsync(p => p.Name == Name);
                if (DeletedProduct==null)
                {
                    _logger.LogError("Ürün Bulunamadı Ürün : "+Name);
                    return null;
                }

                await _repo.DeleteProduct(Name);

                return StatusCode(200, "Ürün Silindi");
            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu" + ex.Message);
                throw;
            }
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> ProductByName(string Name)
        {
            try
            {
                var Product = await _repo.ProductByName(Name);

                if (Product==null)
                {
                    _logger.LogError("Ürün Bulunamadı,  Ürün : "+Name);
                    return null;
                }

                return Ok(Product);
            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu" + ex.Message);
                throw;
            }
        }

        [HttpPatch("{Name}")]
        public async Task<IActionResult> UpdateProduct(string Name, [FromBody]ProductDto product)
        {
            try
            {
                if (product == null)
                {
                    _logger.LogError("İstenen Bilgileri Giriniz");
                    return null;
                }

                await _repo.UpdateProduct(Name, product);

                return Ok("Ürün Güncellendi");
            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu" + ex.Message);
                throw;
            }

        }

        [HttpGet("products-brand")]
        public async Task<IActionResult> ProductsBrands()
        {
            try
            {
                var CustomersBrand = await _repo.ProductsBrands();

                if (!CustomersBrand.Any())
                {
                    _logger.LogError("Liste Getirilirken Bir Hata Oluştu");
                    return NotFound();
                }

                return Ok(CustomersBrand);


            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu" + ex.Message);
                throw;
            }
        }

        [HttpPatch("{price:int}")]
        public async Task<IActionResult> IncrementProductsPrice(int price)
        {
            try
            {
                await _repo.IncrementProductsPrice(price);

                return Ok("Fiyat Artışı Yapıldı");

            }catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu" + ex.Message);
                throw;
            }
        }
    }
}
