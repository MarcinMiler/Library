using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public interface IBorrowService : IService
    {
        Task<BorrowDto> Get(Guid borrowId);
        Task<List<BorrowDto>> GetByUserId(Guid userId);
        Task Add(Guid userId, Guid bookId);
        Task Update(Guid borrowId, DateTime returnDate, string status);
    }
}