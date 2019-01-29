using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public interface IUserService
    {
        UserDto Get(string email);
        void Register(string email, string password, string username);
    }
}