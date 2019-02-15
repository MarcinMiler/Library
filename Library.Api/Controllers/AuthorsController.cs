using System;
using System.Threading.Tasks;
using Library.Infrastructure.Commands;
using Library.Infrastructure.Commands.Authors;
using Library.Infrastructure.DTO;
using Library.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    public class AuthorsController : ApiControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _authorService = authorService;
        }

        [HttpGet("/authors/{id}")]
        public async Task<AuthorDto> Get(Guid id) => await _authorService.Get(id);

        [HttpPost("/authors")]
        public async Task<ActionResult> Post([FromBody]CreateAuthor command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created("users", new object());
        }
    }
}