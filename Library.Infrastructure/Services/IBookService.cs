using System;
using System.Threading.Tasks;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public interface IBookService : IService
    {
        Task<BookDto> Get(string title);
        Task Add(string title, Guid authorId);
    }
}