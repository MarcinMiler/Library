using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Domain;
using Library.Core.Respository;
using Library.Infrastructure.EF;
using Library.Infrastructure.Respository;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository
{
    public class UserRepository : IUserRepository, ISqlRepository
    {
        private readonly LibraryContext _context;

        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<User> Get(Guid id)
            => await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<User> Get(string email)
            => await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

        public async Task<IEnumerable<User>> GetAll()
            => await _context.Users.ToListAsync();

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await Get(id);
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}