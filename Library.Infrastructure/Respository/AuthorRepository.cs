using System;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Domain;
using Library.Core.Repository;
using Library.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Respository
{
    public class AuthorRepository : IAuthorRepository, ISqlRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Author> Get(Guid id)
            => await _context.Authors.SingleOrDefaultAsync(x => x.Id == id);

        public async Task Add(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }
    }
}