using System;
using System.Collections.Generic;

namespace Library.Infrastructure.DTO
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }

        public List<AuthorBook> Books { get; set; }
    }

    public class AuthorBook
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}