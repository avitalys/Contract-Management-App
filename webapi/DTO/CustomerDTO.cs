namespace webapi.DTO
{
    public class CustomerDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO Address { get; set; } 
        public List<ContractDTO>? Contracts { get; set; }
    }
}