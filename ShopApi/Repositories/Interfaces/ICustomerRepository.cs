using ShopApi.Dtos;
using ShopApi.Models;

namespace ShopApi.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddCustomers(CustomerDto Customer); 
        Task DeleteCustomers(string LastName); 
        Task UpdateCustomer(string LastName, CustomerDto customer); 
        Task<List<CustomerDto>> AllCustomers(); // Tüm Customerları Getir
        Task<CustomerDto> CustomerByName(string LastName); // İsime Gçre Customer Getir
        Task<List<CustomerDto>> GetCustomersProduct();
        Task<List<CustomerDto>> GetCustomersBrands();
    };
}
