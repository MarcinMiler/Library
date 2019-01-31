using System;
using System.Threading.Tasks;
using Library.Core.Domain;
using Library.Core.Respository;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public async Task<UserDto> Get(string email)
        {
            var user = await userRepository.Get(email);

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username
            };
        }

        public async Task Register(string email, string password, string username)
        {
            var user = await userRepository.Get(email);

            if (user != null)
            {
                throw new Exception("Email is in use");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, password, salt, username);

            await userRepository.Add(user);
        }
    }
}