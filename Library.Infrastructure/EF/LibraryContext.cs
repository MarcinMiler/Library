using Library.Core.Domain;
using Library.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.EF
{
    public class LibraryContext : DbContext
    {
        private readonly SqlSettings _sqlSettings;
        public DbSet<User> Users { get; set; }

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
            var userBuilder = modelBuilder.Entity<User>();
            userBuilder.HasKey(x => x.Id);
        }
    }
}