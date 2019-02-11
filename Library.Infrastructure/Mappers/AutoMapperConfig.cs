using AutoMapper;
using Library.Core.Domain;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize() =>
            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Author, AuthorDto>();
                cfg.CreateMap<Book, BookDto>();
            })
            .CreateMapper();
    }
}