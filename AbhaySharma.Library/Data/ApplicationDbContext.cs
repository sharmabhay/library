using AbhaySharma.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace AbhaySharma.Library.Data
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<BookShelf> BookShelves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=/Users/abhaysharma/RiderProjects/library/db/library_db.sqlite");
    }
}