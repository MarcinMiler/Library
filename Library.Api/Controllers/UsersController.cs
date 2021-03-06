﻿using System;
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

        [HttpGet("/users/{email}")]
        public async Task<UserDto> Get(string email) => await _userService.Get(email);

        [HttpGet("/users/id/{id}")]
        public async Task<UserDto> Get(Guid id) => await _userService.Get(id);

        [HttpPost("/users")]
        public async Task<ActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created("users", new object());
        }
    }
}
