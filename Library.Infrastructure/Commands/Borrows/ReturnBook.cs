using System;

namespace Library.Infrastructure.Commands.Borrows
{
    public class ReturnBook : ICommand
    {
        public Guid borrowId { get; set; }
        public Guid bookId { get; set; }
    }
}