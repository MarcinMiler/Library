using System;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Domain;
using Library.Core.Repository;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Get(Guid id)
        {
            var author = await _authorRepository.Get(id);

            return _mapper.Map<Author, AuthorDto>(author);
        }

        public async Task Add(string fullname)
        {
            var author = new Author(Guid.NewGuid(), fullname);

            await _authorRepository.Add(author);
        }

    }
}