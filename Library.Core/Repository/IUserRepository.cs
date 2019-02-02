using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Domain;
using Library.Core.Repository;

namespace Library.Core.Respository
{
    public interface IUserRepository : IRepository
    {
        Task<User> Get(Guid id);
        Task<User> Get(string email);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
        Task Delete(Guid id);
        Task Update(User user);
    }
}