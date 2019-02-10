using System.Threading.Tasks;
using Library.Infrastructure.Commands;
using Library.Infrastructure.Commands.Authors;
using Library.Infrastructure.Services;

namespace Library.Infrastructure.Handlers.Authors
{
    public class CreateAuthorHandler : ICommandHandler<CreateAuthor>
    {
        private readonly IAuthorService _authorService;

        public CreateAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task HandleAsync(CreateAuthor command)
        {
            await _authorService.Add(command.Fullname);
        }
    }
}