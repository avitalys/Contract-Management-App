
using System.ComponentModel.DataAnnotations;
using webapi.Enums;

namespace webapi.Models
{
    public class Package
    {
        public PackageType Type { get; set; }
        [Required]
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Used { get; set; }

        public Package(PackageType type, string name, int amount)
        {
            Type = type;
            Name = name;
            Amount = amount;
        }
    }
}