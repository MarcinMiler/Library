using System;

namespace Library.Core.Domain
{
    public class Book
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public int Stock { get; protected set; }

        public Guid AuthorId { get; protected set; }
        public Author Author { get; protected set; }

        public Book(Guid id, string title, Guid authorId, int stock)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            Stock = stock;
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
            {
                return;
            }

            Stock = stock;
        }
    }
}