using webapi.Models;

namespace webapi.Intefaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(string id);

        void UpdateCustomer(Customer customer);
        Task<bool> SaveAllAsync();

    }
}