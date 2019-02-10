using System;
using System.Threading.Tasks;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public interface IAuthorService : IService
    {
        Task<AuthorDto> Get(Guid id);
        Task Add(string fullname);
    }
}