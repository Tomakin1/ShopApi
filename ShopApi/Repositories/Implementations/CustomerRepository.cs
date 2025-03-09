using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ShopApi.Context;
using ShopApi.Dtos;
using ShopApi.Models;
using ShopApi.Repositories.Interfaces;


namespace ShopApi.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMemoryCache _cache;
        private readonly ShopContext _db;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(ShopContext db, ILogger<CustomerRepository> logger, IMemoryCache cache)
        {
            _db = db;
            _logger = logger;
            _cache = cache;
        }

        public  async Task<List<CustomerDto>> AllCustomers() 
        {
            try
            {

                var CacheKey = "AllCustomers";
                if (_cache.TryGetValue(CacheKey,out List<CustomerDto> CachedCustomers))
                {
                    if (CachedCustomers!=null)
                    {
                        return CachedCustomers;
                    }
                }
                var Customers = await _db.Customers.AsNoTracking()
                            .Include(c => c.CustomerDetail) 
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
                _cache.Set(CacheKey, Customers,TimeSpan.FromMinutes(60));
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
            using var transaction = await _db.Database.BeginTransactionAsync();
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

                await transaction.CommitAsync();

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu" + ex);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<CustomerDto> CustomerByName(string LastName)
        {
            try
            {

                var CacheKey = $"Customer_{LastName}";
                if (_cache.TryGetValue(CacheKey,out CustomerDto CachedCustomer))
                {
                    if (CachedCustomer!=null)
                    {
                        return CachedCustomer;
                    }
                }
                var Customer = await _db.Customers.AsNoTracking()
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

                _cache.Set(CacheKey, Customer,TimeSpan.FromMinutes(60));
                return Customer;
                

            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }
        
        //-------------------------GPT KODU---------------------
        public async Task AddCustomers(CustomerDto Dto) // ÖĞREN
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
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

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu: " + ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task DeleteCustomers(string LastName)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
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

                await transaction.CommitAsync();

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
                var CacheKey = $"CustomersProduct";
                if (_cache.TryGetValue(CacheKey, out List<CustomerDto> CachedCustomer))
                {
                    if (CachedCustomer != null)
                    {
                        return CachedCustomer;
                    }
                }
                var CustomersProduct = await _db.Customers.AsNoTracking()
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

                _cache.Set(CacheKey, CustomersProduct,TimeSpan.FromMinutes(60));
                return CustomersProduct;
            }
            catch (Exception)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        //--------------------GPT KODU ÖĞREN---------------------
        public async Task<List<CustomerDto>> GetCustomersBrands()
        {
            try
            {
                var CacheKey = $"CustomersBrands";
                if (_cache.TryGetValue(CacheKey, out List<CustomerDto> CachedCustomer))
                {
                    if (CachedCustomer != null)
                    {
                        return CachedCustomer;
                    }
                }

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

                _cache.Set(CacheKey, customersBrand, TimeSpan.FromMinutes(60));
                return customersBrand; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetCustomersBrands metodu çalışırken hata oluştu.");
                throw;
            }
        }

        public async Task<List<CustomerDto>> firstCustomers(int Num) // verilen sayıya göre ilk kayıtları getirir  TAKE SKİP
        {
            try
            {
                 var FiveCustomer = await _db.Customers.AsNoTracking()
                    .Select(c => new CustomerDto
                    {
                        FirstName = c.FirstName,
                        LastName = c.LastName
                    }).Skip(1).Take(Num).ToListAsync();   //İLK 1 KAYIT SKİPLE ATLANDI KULLANICININ VERDİĞİ SAYI KADAR KAYIT TAKE İLE GETİRİLDİ

                if (!FiveCustomer.Any() || FiveCustomer.Count==0)
                {
                    _logger.LogError("Liste Getirilirken Bir Hata Oluştu");
                    return new List<CustomerDto>();
                    
                }

                return FiveCustomer;
            }
            catch(Exception ex)
            {
                _logger.LogCritical("Bilinmeyen Bir Hata Oluştu");
                throw;
            }

        }

    }
}
