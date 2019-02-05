using System;
using System.Threading.Tasks;
using Library.Infrastructure.Commands;
using Library.Infrastructure.Commands.Login;
using Library.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Library.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginController(ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler, IMemoryCache cache)
            : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task<IActionResult> Post([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);

            var jwt = _cache.Get(command.TokenId);

            return Json(jwt);
        }
    }
}