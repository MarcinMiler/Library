using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Infrastructure.Commands;
using Library.Infrastructure.Commands.Borrows;
using Library.Infrastructure.DTO;
using Library.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    public class BorrowsController : ApiControllerBase
    {
        private readonly IBorrowService _borrowService;

        public BorrowsController(IBorrowService borrowService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _borrowService = borrowService;
        }

        [HttpGet("/borrows/{id}")]
        public async Task<BorrowDto> Get(Guid id) => await _borrowService.Get(id);

        [HttpGet("/borrows/userId/{id}")]
        public async Task<List<BorrowDto>> GetByUserId(Guid id) => await _borrowService.GetByUserId(id);

        [HttpPost("/borrows/borrow")]
        public async Task<ActionResult> Post([FromBody]BorrowBook command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created("borrows", null);
        }

        [HttpPost("/borrows/return")]
        public async Task<ActionResult> Post([FromBody]ReturnBook command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created("borrows", new object());
        }
    }
}