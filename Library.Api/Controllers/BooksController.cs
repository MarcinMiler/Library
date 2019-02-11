using System;
using System.Threading.Tasks;
using Library.Infrastructure.Commands;
using Library.Infrastructure.Commands.Books;
using Library.Infrastructure.DTO;
using Library.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    public class BooksController : ApiControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _bookService = bookService;
        }

        [HttpGet("{title}")]
        public async Task<BookDto> Get(string title) => await _bookService.Get(title);

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateBook command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created("books", new object());
        }
    }
}