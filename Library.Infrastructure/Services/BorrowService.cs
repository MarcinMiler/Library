using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Domain;
using Library.Core.Repository;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IMapper _mapper;

        public BorrowService(IBorrowRepository borrowRepository, IMapper mapper)
        {
            _borrowRepository = borrowRepository;
            _mapper = mapper;
        }

        public async Task<BorrowDto> Get(Guid borrowId)
        {
            var borrow = await _borrowRepository.Get(borrowId);

            return _mapper.Map<Borrow, BorrowDto>(borrow);
        }

        public async Task<List<BorrowDto>> GetByUserId(Guid userId)
        {
            var borrows = await _borrowRepository.GetByUserId(userId);
            Console.WriteLine(borrows.ToString(), userId, "LUL");
            return _mapper.Map<List<Borrow>, List<BorrowDto>>(borrows);
        }

        public async Task Add(Guid userId, Guid bookId)
        {
            var borrow = new Borrow(userId, bookId);
            await _borrowRepository.Add(borrow);
        }

        public async Task Update(Guid borrowId, DateTime returnDate, string status)
        {
            var borrow = await _borrowRepository.Get(borrowId);

            if (borrow == null)
            {
                return;
            }

            borrow.SetReturnDate(returnDate);
            borrow.SetStatus(status);

            await _borrowRepository.Update(borrow);
        }
    }
}