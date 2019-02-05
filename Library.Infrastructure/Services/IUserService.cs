using System.Threading.Tasks;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> Get(string email);
        Task Login(string email, string password);
        Task Register(string email, string password, string username);
    }
}