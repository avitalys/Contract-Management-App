using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.DTO;
using webapi.Intefaces;
using webapi.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace webapi.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            return await _context.Customers
                .Include(cust => cust.Address)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers
                .Include(cust => cust.Address)
                .ToListAsync();
        }

        public async Task<CustomerDTO> GetCustomerDTOByIdAsync(string id)
        {
            return await _context.Customers
                .Where(x => x.Id == id)
                .ProjectTo<CustomerDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomersDTOAsync()
        {
            return await _context.Customers
                .ProjectTo<CustomerDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateCustomer(Customer destCustomer, CustomerUpdateDTO customerUpdate)
        {
            _mapper.Map(customerUpdate, destCustomer.Address);
            _context.Entry(destCustomer).State = EntityState.Modified;
        }
    }
}