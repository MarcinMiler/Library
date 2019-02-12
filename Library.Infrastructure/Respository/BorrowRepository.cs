using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Domain;
using Library.Core.Repository;
using Library.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Respository
{
    public class BorrowRepository : IBorrowRepository, ISqlRepository
    {
        private readonly LibraryContext _context;

        public BorrowRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Borrow> Get(Guid borrowId)
            => await _context.Borrows.SingleOrDefaultAsync(x => x.Id == borrowId);

        public async Task<List<Borrow>> GetByUserId(Guid userId)
            => await _context.Borrows.Where(x => x.UserId == userId).ToListAsync();

        public async Task Add(Borrow borrow)
        {
            _context.Borrows.Update(borrow);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Borrow borrow)
        {
            _context.Borrows.Update(borrow);
            await _context.SaveChangesAsync();
        }
    }
}