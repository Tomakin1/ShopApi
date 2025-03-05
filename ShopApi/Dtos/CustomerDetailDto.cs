namespace ShopApi.Dtos
{
    public class CustomerDetailDto
    {
        public string? Address { get; set; } = default!;
        public int? Age { get; set; }
        public string? Job { get; set; } = default!;
        public bool? Gender { get; set; }
    }
}
