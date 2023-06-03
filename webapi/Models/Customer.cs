using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace webapi.Models
{
    public class Customer
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public Address? Address { get; set; }
        public List<Contract>? Contracts { get; set; }

    }
}