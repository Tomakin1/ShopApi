using ShopApi.Dtos;
using ShopApi.Models;

public class CustomerDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public int TCKN { get; set; }

    public ICollection<ProductDto>? Products { get; set; } = new List<ProductDto>();
    public ICollection<CustomersBrandDto>? CustomersBrands { get; set; } = new List<CustomersBrandDto>();
    public CustomerDetailDto? CustomerDetail { get; set; }
}


