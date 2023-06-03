using webapi.DTO;
using webapi.Models;

namespace webapi.Intefaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(string id);

        Task<IEnumerable<CustomerDTO>> GetCustomersDTOAsync();
        Task<CustomerDTO> GetCustomerDTOByIdAsync(string id);
        void UpdateCustomer(Customer customer);
        Task<bool> SaveAllAsync();

    }
}