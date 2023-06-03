using webapi.Enums;
using webapi.Models;

namespace webapi.DTO
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContractType Type { get; set; }
        public List<Package>? Packages { get; set; }

    }
}