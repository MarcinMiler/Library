using System;

namespace Library.Infrastructure.Commands.Books
{
    public class CreateBook : ICommand
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public int Stock { get; set; }
    }
}