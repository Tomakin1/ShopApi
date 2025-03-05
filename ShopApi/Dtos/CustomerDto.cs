using ShopApi.Dtos;

public class CustomerDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public int TCKN { get; set; }

    public ICollection<ProductDto>? Products { get; set; } = new List<ProductDto>();
    public ICollection<CustomerDetailDto>? CustomerDetails { get; set; } = new List<CustomerDetailDto>();

    public CustomerDetailDto? CustomerDetail { get; set; }  // CustomerDetail iç içe olabilir
}

public class CustomerDetailDto
{
    public string? Address { get; set; } = default!;
    public int? Age { get; set; }
    public string? Job { get; set; } = default!;
    public bool? Gender { get; set; }
}
