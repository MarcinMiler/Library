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
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        // [Authorize]
        public async Task<UserDto> Get(string email) => await _userService.Get(email);

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created("users", new object());
        }

        // [HttpGet]
        // [Route("token")]
        // public IActionResult Get()
        // {
        //     var token = _jwtHandler.CreateToken(Guid.NewGuid(), "user");
        //     return Ok(token);
        // }
    }
}
