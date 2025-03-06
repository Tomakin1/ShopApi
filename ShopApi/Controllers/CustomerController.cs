using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Dtos;
using ShopApi.Models;
using ShopApi.Repositories.Interfaces;

namespace ShopApi.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerRepository repo, ILogger<CustomerController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> AllCustomers()
        {
            try
            {
                var customerList = await _repo.AllCustomers();
                if (!customerList.Any())
                {
                    _logger.LogError("Liste Getirilirken Bir Hata Oluştu");
                    return NotFound(new List<CustomerDto>());
                }

                return Ok(customerList);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata Oluştu: " + ex.Message);
                throw; 
                // Global Hata Yönetimi olmadığı için throw yerine tercih edildi fakat best practice Global Hata Yönetimi ve throw kullanımı
            }
        }

        [HttpGet("customers-product")]
        public async Task<IActionResult> GetCustomersProduct()
        {
            try
            {
                var CustomersProduct = await _repo.GetCustomersProduct();

                if (CustomersProduct==null)
                {
                    _logger.LogWarning("Liste Getirilirken Bir Hata Oluştu");
                    return null;
                }

                return Ok(CustomersProduct);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata Oluştu"+ex.Message);
                throw;
            }
        }

        [HttpPatch("{LastName}")] // TEST ET
        public async Task<IActionResult> UpdateCustomer(string LastName, [FromBody] CustomerDto customerDto)
        {
            try
            {
                await _repo.UpdateCustomer(LastName, customerDto);

                return StatusCode(200, "Müşteri Güncellendi");
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata Oluştu: " + ex.Message);
                throw;
            }
        }

        [HttpGet("{LastName}")]
        public async Task<IActionResult> CustomerByName(string LastName)
        {
            try
            {
                var customer = await _repo.CustomerByName(LastName);

                if (customer == null)
                {
                    _logger.LogError("Müşteri Bulunamadı  İSİM: " + LastName);
                    return NotFound();
                }

                return Ok(customer);

            }
            catch (Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata Oluştu: " + ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomers([FromBody] CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null)
                {
                    _logger.LogError("Bilgileri Giriniz");
                    return BadRequest();
                }
                await _repo.AddCustomers(customerDto);
                return StatusCode(201,customerDto);

            }
            catch (Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata oluştu: " + ex.Message);
                throw;
            }
        }

        [HttpDelete("{LastName}")]
        public async Task<IActionResult> DeleteCustomers(string LastName)
        {
            try
            {
                await _repo.DeleteCustomers(LastName);

                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata oluştu: " + ex.Message);
                throw;
            }
        }
        [HttpGet("Customers-brand")]
        public async Task<IActionResult> GetCustomersBrands()
        {
            try
            {
                var CustomersBrand = await _repo.GetCustomersBrands();

                if (!CustomersBrand.Any())
                {
                    _logger.LogError("Liste Getirilirken Bir Hata Oluştu");
                    return NotFound();
                }

                return Ok(CustomersBrand);

            }
            catch(Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata Oluştu"+ex.Message);
                throw;
            }
        }
    }
}
