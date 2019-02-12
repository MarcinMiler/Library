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

        [HttpGet("{id}")]
        public async Task<BorrowDto> Get(Guid id) => await _borrowService.Get(id);

        // [HttpGet("{id}")]
        // public async Task<List<BorrowDto>> Get(Guid id) => await _borrowService.GetByUserId(id);

        // [HttpPost]
        // public async Task<ActionResult> Post([FromBody]BorrowBook command)
        // {
        //     await CommandDispatcher.DispatchAsync(command);

        //     return Created("borrows", new object());
        // }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ReturnBook command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created("borrows", new object());
        }
    }
}