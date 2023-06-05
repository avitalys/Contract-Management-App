using webapi.Models;

namespace webapi.Intefaces
{
public interface ITokenService
    {
        string CreateToken(Customer customer);
    }
}