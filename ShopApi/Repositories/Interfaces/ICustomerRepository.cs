using ShopApi.Dtos;
using ShopApi.Models;

namespace ShopApi.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddCustomers(CustomerDto Customer); // Post
        Task DeleteCustomers(string LastName); // Delete
        Task UpdateCustomer(string LastName, CustomerDto customer); // Update
        Task<List<CustomerDto>> AllCustomers(); // Tüm Customerları Getir
        Task<CustomerDto> CustomerByName(string LastName); // İsime Gçre Customer Getir
        Task<List<CustomerDto>> GetCustomersProduct();
    }
}
