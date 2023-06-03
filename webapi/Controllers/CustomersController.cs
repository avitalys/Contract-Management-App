using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // GET /api/customers
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;
        public CustomersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            return customers;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(string id)
        {
            return await _context.Customers.FindAsync(id);
        }
    }
}