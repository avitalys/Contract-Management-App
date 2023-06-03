
using System.ComponentModel.DataAnnotations;
using webapi.Enums;

namespace webapi.Models
{
    public class Contract
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ContractType Type { get; set; }
        public List<Package>? Packages { get; set; }

        public Contract(string id, string name, ContractType type = ContractType.Visitor)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}