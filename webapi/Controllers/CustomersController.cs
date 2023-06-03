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
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(string id)
        {
            var customer  = await _customerRepository.GetCustomerDTOByIdAsync(id);
            return Ok(customer);
        }

        [HttpPut("{id}")] // PUT: /api/customers/{id}
        public async Task<ActionResult> PutCustomerAddressByCustomerId(string id, CustomerUpdateDTO updateAddress)
        {
            if (id != updateAddress.CustomerId)
            {
                return BadRequest();
            }

            var user = await _customerRepository.GetCustomerByIdAsync(id);

            if (user == null) return NotFound();

            _customerRepository.UpdateCustomer(user, updateAddress);

            if (await _customerRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }
    }
}