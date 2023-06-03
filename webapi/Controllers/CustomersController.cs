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
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet] // GET: /api/customers
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customers  = await _customerRepository.GetCustomersAsync();
            var customersToReturns =  _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customersToReturns);
        }
        
        [HttpGet("{id}")] // GET: /api/customers/{id}
        public async Task<ActionResult<CustomerDTO>> GetCustomer(string id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            var customerToReturns =  _mapper.Map<CustomerDTO>(customer);
            return Ok(customerToReturns);
        }

        // [HttpPost("details")] // POST: /api/customers/details
        // public async Task<ActionResult<CustomerDetails>> GetCustomerDetails(string id)
        // {
        //     return await _context.Addresses.FindAsync(id);
        // }
    }
}