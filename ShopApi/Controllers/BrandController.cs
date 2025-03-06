using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Dtos;
using ShopApi.Repositories.Interfaces;

namespace ShopApi.Controllers
{
    [Route("brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _repo;
        private readonly ILogger<BrandController> _logger;

        public BrandController(IBrandRepository repo, ILogger<BrandController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody]BrandDto brand)
        {
            try
            {
                if (brand==null)
                {
                    _logger.LogError("İstenen Bilgileri Giriniz");
                    return null;
                }

                await _repo.addBrand(brand);

                return StatusCode(201, "Brand Eklendi");

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir HATA Oluştu"+ex.Message);
                throw;
            }
        }

        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteBrand(string Name)
        {
            try
            {
                await _repo.removeBrand(Name);

                return Ok("Ürün Silindi");

            }catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu" + ex.Message);
                 throw;
            }
        }

        [HttpPatch("{Name}")]
        public async Task<IActionResult> UpdateBrand(string Name, [FromBody]BrandDto brand)
        {
            try
            {
                if (brand == null)
                {
                    _logger.LogError("İstenen Bilgileri Giriniz");
                    return null;
                }

                await _repo.UpdateBrand(Name, brand);

                return Ok(brand);
            }
            catch(Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata Oluştu"+ex.Message);
                throw;
            }


        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            try
            {
                var Brands = await _repo.GetBrands();

                if (!Brands.Any())
                {
                    _logger.LogError("Liste Getirilirken Bir Hata oluştu");
                    return null;
                }

                return Ok(Brands);
            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu" + ex.Message);
                throw;
            }

        }

        [HttpDelete("{BrandName}/{productName}")]
        public async Task<IActionResult> DeleteBrandsProduct(string brandName, string productName)
        {
            try
            {
                var DeletedProduct = await _repo.DeleteBrandsProduct(brandName, productName);

                return Ok(DeletedProduct);



            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu" + ex.Message);
                throw;
            }
        }
    }
}
