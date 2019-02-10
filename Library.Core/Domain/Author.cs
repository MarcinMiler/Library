using System;
using System.Collections.Generic;

namespace Library.Core.Domain
{
    public class Author
    {
        public Guid Id { get; protected set; }
        public string Fullname { get; protected set; }

        public ICollection<Book> Books { get; protected set; }

        public Author(Guid id, string fullname)
        {
            Id = id;
            Fullname = fullname;
        }
    }
}