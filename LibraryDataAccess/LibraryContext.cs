using LibraryDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryDataAccess
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Publisher> PublishingHouses { get; set; }
    }
}
