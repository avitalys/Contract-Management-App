
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.Enums;

namespace webapi.Models
{
    [Table("Contracts")]
    public class Contract
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ContractType Type { get; set; }
        public List<Package>? Packages { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}