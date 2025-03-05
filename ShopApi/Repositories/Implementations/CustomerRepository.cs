using Microsoft.EntityFrameworkCore;
using ShopApi.Context;
using ShopApi.Dtos;
using ShopApi.Models;
using ShopApi.Repositories.Interfaces;


namespace ShopApi.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShopContext _db;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(ShopContext db, ILogger<CustomerRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public  async Task<List<CustomerDto>> AllCustomers() // Tekrar Et
        {
            try
            {
                var Customers = await _db.Customers
                            .Include(c => c.CustomerDetail) // KULLANMASAN DA OLUR CUSTOMER NESNESİ OLARAK TÜM VERİLERİ ÇEKMEYİP SELECT İLE DTO DÖNÜŞÜMÜ YAPILDIĞI İÇİN INCLUDE KULLANILMAYABİLİR
                            .Select(c => new CustomerDto
                            {
                                FirstName=c.FirstName,
                                LastName=c.LastName,
                                Email=c.Email,
                                TCKN = c.TCKN,
                                CustomerDetail = new CustomerDetailDto
                                {
                                    Address=c.CustomerDetail.Address,
                                    Age=c.CustomerDetail.Age,
                                    Gender=c.CustomerDetail.Gender,
                                    Job = c.CustomerDetail.Job
                                }

                            }).ToListAsync();
                        
            

                if (!Customers.Any())
                {
                    _logger.LogError("Liste Getirilirken Bir Hata Oluştu");
                    return new List<CustomerDto>();
                }

                return Customers;
            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu"+ex);
                throw;
            }
        }

        public async Task UpdateCustomer(string LastName, CustomerDto customer)
        {
            try
            {
                var Customer = await _db.Customers
                        .FirstOrDefaultAsync(c => c.LastName == LastName);
                if (Customer==null)
                {
                    _logger.LogError("Verilen İsme Dair Kullanıcı Bulunamadı"+ LastName);
                    return;
                }

                if (customer==null)
                {
                    _logger.LogError("İstenen Bilgileri Giriniz");
                    return;
                }

                Customer.FirstName = customer.FirstName;
                Customer.LastName = customer.LastName;
                Customer.TCKN = customer.TCKN;
                Customer.Email = customer.Email;

                 _db.Customers.Update(Customer);
                await _db.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu" + ex);
                throw;
            }
        }

        public async Task<CustomerDto> CustomerByName(string LastName)
        {
            try
            {
                var Customer = await _db.Customers
                           .Where(c => c.LastName == LastName)
                           .Select(c => new CustomerDto // Her Bir Customer nesnesi = c , her c için yeni bir CustomerDto nesnesi Oluşturur
                           {
                               
                               FirstName=c.FirstName,
                               LastName=c.LastName,
                               Email= c.Email,
                               TCKN = c.TCKN,
                               CustomerDetail= new CustomerDetailDto   // CustomerDetailDto Nesnesi içine Atama İçin Yeni bir CustomerDetailDto Nesnesi Oluştur
                               {
                                   Address=c.CustomerDetail.Address,  // Her  CustomerDetailDto Nesnesi için Customer tablosundan CustomerDetail nav-prop'undan Atama Yapılıyor
                                   Age=c.CustomerDetail.Age,
                                   Job=c.CustomerDetail.Job,
                                   Gender=c.CustomerDetail.Gender
                               }


                           }).FirstOrDefaultAsync();

                if (Customer==null)
                {
                    _logger.LogError("Müşteri Getirilirken Bir Hata Oluştu İsim : "+ LastName);
                    return null;
                }

                return Customer;

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        public async Task AddCustomers(CustomerDto Dto) // ÖĞREN
        {
            try
            {
                if (Dto == null)
                {
                    _logger.LogError("İstenen Bilgileri Giriniz");
                    return;
                }

                var NewCustomer = new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = Dto.FirstName,
                    LastName = Dto.LastName,
                    Email = Dto.Email,
                    TCKN = Dto.TCKN,
                    CustomerDetail = Dto.CustomerDetail != null ? new CustomerDetail
                    {
                        Address = Dto.CustomerDetail.Address,
                        Age = Dto.CustomerDetail.Age,
                        Job = Dto.CustomerDetail.Job,
                        Gender = Dto.CustomerDetail.Gender
                    } : null 

                };

                await _db.Customers.AddAsync(NewCustomer);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu: " + ex.Message);
                throw;
            }
        }


        public async Task DeleteCustomers(string LastName)
        {
            try
            {
                var DeletedCustomer = await _db.Customers.FirstOrDefaultAsync(c => c.LastName == LastName);
                if (DeletedCustomer==null)
                {
                    _logger.LogError("Kullanıcı Bulunamadı İsim: "+LastName);
                    return;
                }

                _db.Customers.Remove(DeletedCustomer);
               await _db.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        public async Task<List<CustomerDto>> GetCustomersProduct()
        {
            try
            {
                var CustomersProduct = await _db.Customers
                        .Include(c => c.Products)
                        .Select(c => new CustomerDto
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Email = c.Email,
                            TCKN = c.TCKN,
                            Products = c.Products.Select(p => new ProductDto
                            {
                                Name=p.Name,
                                Title=p.Title,
                                Description=p.Description,
                                price=p.price,
                                BrandId=p.BrandId,
                                CustomerId=p.CustomerId
                                
                            }).ToList()
                        }).ToListAsync();

                if (!CustomersProduct.Any())
                {
                    _logger.LogError("Liste Getirilirken Bir HATA Oluştu");
                    return new List<CustomerDto>();
                }

                return CustomersProduct;
            }
            catch (Exception)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        public async Task<List<CustomerDto>> GetCustomersBrands()
        {
            try
            {
                var customersBrand = await _db.Customers
                    .Include(c => c.CustomersBrands)
                        .ThenInclude(cb=>cb.Brand)
                    .Select(c => new CustomerDto
                    {
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        TCKN = c.TCKN,
                        CustomersBrands = c.CustomersBrands.Select(b => new CustomersBrandDto
                        {
                            BrandId = b.BrandId,
                            BrandName = b.Brand.Name
                        }).ToList()
                    }).ToListAsync();

                return customersBrand; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetCustomersBrands metodu çalışırken hata oluştu.");
                throw;
            }
        }

    }
}
