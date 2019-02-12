using System;

namespace Library.Infrastructure.Commands.Borrows
{
    public class BorrowBook : ICommand
    {
        public Guid userId { get; set; }
        public Guid bookId { get; set; }
    }
}