using System;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Domain;
using Library.Core.Respository;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Get(string email)
        {
            var user = await _userRepository.Get(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task Login(string email, string password)
        {
            var user = await _userRepository.Get(email);

            if (user == null)
            {
                throw new Exception("Invalid Credentials.");
            }

            if (password == user.Password)
            {
                return;
            }

            throw new Exception("Invalid Credentials.");
        }

        public async Task Register(string email, string password, string username)
        {
            var user = await _userRepository.Get(email);

            if (user != null)
            {
                throw new Exception("Email is in use");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, password, salt, username);

            await _userRepository.Add(user);
        }
    }
}