using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Domain;

namespace Library.Core.Repository
{
    public interface IBorrowRepository : IRepository
    {
        Task<Borrow> Get(Guid borrowId);
        Task<List<Borrow>> GetByUserId(Guid userId);
        Task Add(Borrow borrow);
        Task Update(Borrow borrow);
    }
}