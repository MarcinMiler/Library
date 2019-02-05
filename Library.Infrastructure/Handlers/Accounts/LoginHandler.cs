using System;
using System.Threading.Tasks;
using Library.Infrastructure.Commands;
using Library.Infrastructure.Commands.Login;
using Library.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Library.Infrastructure.Handlers.Accounts
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(Login command)
        {
            await _userService.Login(command.Email, command.Password);

            var user = await _userService.Get(command.Email);

            var jwt = _jwtHandler.CreateToken(user.Id, "user");
            _cache.Set(command.TokenId, jwt, TimeSpan.FromSeconds(5));
        }
    }
}