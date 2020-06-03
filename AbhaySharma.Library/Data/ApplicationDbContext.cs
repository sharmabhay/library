using System;
using System.Linq;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(book => book.Genres).HasConversion(
                genres =>
                    genres.Select(genre => genre.ToString()).
                        Aggregate((a, c) => $"{a} & {c}"),
                dbResult =>
                    dbResult.Split(" & ", StringSplitOptions.RemoveEmptyEntries).
                        Select(genreString => (Genre)Enum.Parse(typeof(Genre), genreString)).ToList()
            );
            modelBuilder.Entity<Book>().Property(book => book.Rating).HasConversion(
                rating =>
                    rating.ToString(),
                dbResult =>
                    (Rating)Enum.Parse(typeof(Rating), dbResult)
            );
        }
    }
}