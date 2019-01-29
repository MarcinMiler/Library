using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Infrastructure.DTO;
using Library.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("{email}")]
        public UserDto Get(string email) => userService.Get(email);
    }
}
