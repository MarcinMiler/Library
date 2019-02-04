using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Infrastructure.Commands;
using Library.Infrastructure.Commands.Users;
using Library.Infrastructure.DTO;
using Library.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IJwtHandler _jwtHandler;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
            _jwtHandler = jwtHandler;
        }

        [HttpGet("{email}")]
        [Authorize]
        public async Task<UserDto> Get(string email) => await _userService.Get(email);

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Created("users", new object());
        }

        [HttpGet]
        [Route("token")]
        public IActionResult Get()
        {
            var token = _jwtHandler.CreateToken(Guid.NewGuid(), "user");
            return Ok(token);
        }
    }
}
