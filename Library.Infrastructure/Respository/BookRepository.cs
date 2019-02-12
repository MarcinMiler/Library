using System;
using System.Threading.Tasks;
using Library.Core.Domain;
using Library.Core.Repository;
using Library.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Respository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> Get(string title)
            => await _context.Books.Include(x => x.Author).SingleOrDefaultAsync(x => x.Title == title);

        public async Task<Book> Get(Guid bookId)
            => await _context.Books.Include(x => x.Author).SingleOrDefaultAsync(x => x.Id == bookId);

        public async Task Add(Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}