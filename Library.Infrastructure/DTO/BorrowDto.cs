using System;

namespace Library.Infrastructure.DTO
{
    public class BorrowDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }

        // public UserDto User { get; set; }
        // public BasicBook Book { get; set; }

        // public class BasicBook
        // {
        //     public Guid Id { get; set; }
        //     public string Title { get; set; }
        // }
    }
}