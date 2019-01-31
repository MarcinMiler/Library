using System.Threading.Tasks;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDto> Get(string email);
        Task Register(string email, string password, string username);
    }
}