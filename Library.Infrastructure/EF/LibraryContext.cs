using Library.Core.Domain;
using Library.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.EF
{
    public class LibraryContext : DbContext
    {
        private readonly SqlSettings _sqlSettings;

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options, SqlSettings sqlSettings)
            : base(options)
        {
            _sqlSettings = sqlSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_sqlSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Book>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Author>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Borrow>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Author>()
                .HasMany<Book>(x => x.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<User>()
                .HasMany<Borrow>(x => x.BorrowedBooks)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}