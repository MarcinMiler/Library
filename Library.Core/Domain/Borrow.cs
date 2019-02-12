using System;

namespace Library.Core.Domain
{
    public class Borrow
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Guid BookId { get; protected set; }
        public DateTime BorrowDate { get; protected set; }
        public DateTime? ReturnDate { get; protected set; }
        public string Status { get; protected set; }

        public User User { get; protected set; }

        public Borrow(Guid userId, Guid bookId)
        {
            UserId = userId;
            BookId = bookId;
            BorrowDate = DateTime.Now;
            Status = "Borrowed";
        }

        public void SetReturnDate(DateTime returnDate)
        {
            if (returnDate == null)
            {
                return;
            }

            ReturnDate = returnDate;
        }

        public void SetStatus(string status)
        {
            Status = status;
        }
    }
}