using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTO;
using webapi.Intefaces;
using webapi.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet] // GET: /api/customers
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customers  = await _customerRepository.GetCustomersDTOAsync();
            return Ok(customers);
        }
        
        [HttpGet("{id}")] // GET: /api/customers/{id}
        public async Task<ActionResult<CustomerDTO>> GetCustomer(string id)
        {
            var customer  = await _customerRepository.GetCustomerDTOByIdAsync(id);
            return Ok(customer);
        }

        // [HttpPost("details")] // POST: /api/customers/details
        // public async Task<ActionResult<CustomerDetails>> GetCustomerDetails(string id)
        // {
        //     return await _context.Addresses.FindAsync(id);
        // }
    }
}