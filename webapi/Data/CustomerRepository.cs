using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Intefaces;
using webapi.Models;

namespace webapi.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers
                .Include(cust => cust.Address)
                .ToListAsync();
        }

        async Task<bool> ICustomerRepository.SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        void ICustomerRepository.UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}