using System;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Domain;
using Library.Core.Repository;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepoistory;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepoistory, IMapper mapper)
        {
            _bookRepoistory = bookRepoistory;
            _mapper = mapper;
        }

        public async Task<BookDto> Get(string title)
        {
            var book = await _bookRepoistory.Get(title);

            return _mapper.Map<Book, BookDto>(book);
        }

        public async Task Add(string title, Guid authorId)
        {
            var book = new Book(Guid.NewGuid(), title, authorId);

            await _bookRepoistory.Add(book);
        }
    }
}