using System;
using System.Threading.Tasks;
using Library.Core.Domain;

namespace Library.Core.Repository
{
    public interface IBookRepository : IRepository
    {
        Task<Book> Get(string title);
        Task Add(Book book);
    }
}