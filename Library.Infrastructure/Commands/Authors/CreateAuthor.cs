namespace Library.Infrastructure.Commands.Authors
{
    public class CreateAuthor : ICommand
    {
        public string Fullname { get; set; }
    }
}