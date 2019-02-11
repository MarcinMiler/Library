using System.Threading.Tasks;
using Library.Infrastructure.Commands;
using Library.Infrastructure.Commands.Books;
using Library.Infrastructure.Services;

namespace Library.Infrastructure.Handlers.Books
{
    public class CreateBookHandler : ICommandHandler<CreateBook>
    {
        private readonly IBookService _bookService;

        public CreateBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task HandleAsync(CreateBook command)
        {
            await _bookService.Add(command.Title, command.AuthorId);
        }
    }
}