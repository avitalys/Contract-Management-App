using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Intefaces;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public LoginController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<LoginDTO>> Login(LoginDTO login)
        {
            var user = await _context.Customers.SingleOrDefaultAsync(x => x.Id == login.Id);

            if (user == null) return Unauthorized("invalid username");

            return new LoginDTO
            {
                Id = user.Id,
                Token = _tokenService.CreateToken(user)
            };
        }

    }
}