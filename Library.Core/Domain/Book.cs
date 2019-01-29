using System;

namespace Library.Core.Domain
{
    public class Book
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Author { get; protected set; }

        public Book(Guid bookId, string title, string author)
        {
            Id = bookId;
            Title = title;
            Author = author;
        }
    }
}