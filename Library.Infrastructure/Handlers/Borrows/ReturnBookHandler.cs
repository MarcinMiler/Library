using System;
using System.Threading.Tasks;
using Library.Core.Repository;
using Library.Infrastructure.Commands;
using Library.Infrastructure.Commands.Borrows;
using Library.Infrastructure.Services;

namespace Library.Infrastructure.Handlers.Borrows
{
    public class ReturnBookHandler : ICommandHandler<ReturnBook>
    {
        private readonly IBorrowService _borrowService;
        private readonly IBookService _bookService;
        private readonly IBookRepository _bookRepository;

        public ReturnBookHandler(IBorrowService borrowService, IBookService bookService,
            IBookRepository bookRepository)
        {
            _borrowService = borrowService;
            _bookService = bookService;
            _bookRepository = bookRepository;
        }

        public async Task HandleAsync(ReturnBook command)
        {
            var now = DateTime.UtcNow;

            await _borrowService.Update(command.borrowId, now, "Returned");

            var book = await _bookRepository.Get(command.bookId);

            await _bookService.Update(book, book.Stock + 1);
        }
    }
}