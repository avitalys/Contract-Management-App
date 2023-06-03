namespace webapi.DTO
{
    public class CustomerUpdateDTO
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? zip { get; set; }

        public string CustomerId { get; set; }
    }
}