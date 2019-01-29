using System;
using System.Collections.Generic;
using Library.Core.Domain;

namespace Library.Core.Respository
{
    public interface IUserRepository
    {
        User Get(Guid id);
        User Get(string email);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Delete(Guid id);
        void Update(User user);
    }
}