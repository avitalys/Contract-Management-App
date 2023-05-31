using webapi.Enums;

namespace webapi.Models
{
    public class Package
    {
        public PackageType Type { get; set; }
       // [Required]
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Used { get; set; }
    }
}