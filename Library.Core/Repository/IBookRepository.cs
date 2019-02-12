using System;
using System.Threading.Tasks;
using Library.Core.Domain;

namespace Library.Core.Repository
{
    public interface IBookRepository : IRepository
    {
        Task<Book> Get(string title);
        Task<Book> Get(Guid bookId);
        Task Add(Book book);
        Task Update(Book book);
    }
}