using System;
using System.Threading.Tasks;
using Library.Core.Domain;

namespace Library.Core.Repository
{
    public interface IAuthorRepository : IRepository
    {
        Task<Author> Get(Guid id);
        Task Add(Author author);
    }
}