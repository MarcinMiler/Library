using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public User Get(Guid id) =>
            _users.SingleOrDefault(x => x.Id == id);

        public User Get(string email) =>
            _users.SingleOrDefault(x => x.Email == email);

        public IEnumerable<User> GetAll() => _users;

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}