
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.Enums;

namespace webapi.Models
{
    [Table("Packages")]
    public class Package
    {
        public int Id { get; set; }
        public virtual PackageType Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        public int Used { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}