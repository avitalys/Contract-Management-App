using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("Addresses")]
    public class Address
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? zip { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}