using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Domain;
using Library.Core.Respository;

namespace Library.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("m@m.com", "mm", "mmmmm", "marcinek")
        };
        public async Task<User> Get(Guid id) =>
            await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> Get(string email) =>
            await Task.FromResult(_users.SingleOrDefault(x => x.Email == email));

        public async Task<IEnumerable<User>> GetAll() => await Task.FromResult(_users);

        public async Task Add(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task Delete(Guid id)
        {
            var user = await Get(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task Update(User user)
        {
            await Task.CompletedTask;
        }
    }
}