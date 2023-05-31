using webapi.Enums;

namespace webapi.Models
{
    public class Contract
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ContractType Type { get; set; }
        public List<Package> Packages { get; set; }

         public Contract(string id, string name)
        {
            Id = id;
            Name = name;

        }
    }
}