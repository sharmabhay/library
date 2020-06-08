using System;
using System.Collections.Generic;
using System.Linq;
using AbhaySharma.Library.Data;
using AbhaySharma.Library.Models;

namespace AbhaySharma.Library
{
    public static class Program
    {
        public static void Main()
        {
            /*using var libraryDb = new ApplicationDbContext();
            libraryDb.Books.Add(new Book
            {
                Isbn = 2, Title = "Introduction to F#",
                Author = "Rajat Patwari", Pages = 550,
                Rating = Rating.Mature21,
                Genres = new List<Genre> {Genre.NonFiction, Genre.Thriller, Genre.Mystery}
            });
            var books = libraryDb.Books.Where(currentBook => currentBook.Author == "Rajat Patwari").ToList();
            books.ForEach(book => book.Pages += 50);

            libraryDb.SaveChanges();

            var bookShelf = new BookShelf {Number = 1, AlphabetRange = new AlphabetRange('K', 'U'), Genre = Genre.Comedy};
            bookShelf.Books.Add(new Book
            {
                Title = "Komedy Haven", Author = "Rajat Patwari", Pages = 350, Rating = Rating.ParentalGuidance13,
                Genres = new List<Genre> {Genre.Comedy, Genre.Romance, Genre.SciFi}
            });

            using var libraryDb = new ApplicationDbContext();
            libraryDb.BookShelves.Add(bookShelf);

            libraryDb.SaveChanges();*/
            
            using var libraryDb = new ApplicationDbContext();

            foreach (var bookShelf in libraryDb.BookShelves)
                foreach (var book in bookShelf.Books)
                    Console.WriteLine(book);
        }

        private static void Test1()
        {
            var nonFictionAo = new BookShelf
            {
                Number = 1, Genre = Genre.NonFiction,
                AlphabetRange = new AlphabetRange('A', 'O')
            };

            nonFictionAo.Add(new Book
            {
                Isbn = 1, Title = "Introduction to C#",
                Author = "Rajat Patwari", Pages = 450,
                Rating = Rating.Rated18,
                Genres = new List<Genre> {Genre.NonFiction, Genre.Comedy, Genre.Adventure}
            });
            nonFictionAo.Add(new Book
            {
                Isbn = 2, Title = "Introduction to F#",
                Author = "Rajat Patwari", Pages = 550,
                Rating = Rating.Mature21,
                Genres = new List<Genre> {Genre.NonFiction, Genre.Thriller, Genre.Mystery}
            });
            nonFictionAo.Add(new Book
            {
                Isbn = 3, Title = "Introduction to Java",
                Author = "Angie Yoon", Pages = 350,
                Rating = Rating.ParentalGuidance13,
                Genres = new List<Genre> {Genre.NonFiction, Genre.Horror}
            });
            nonFictionAo.Add(new Book
            {
                Isbn = 4, Title = "Introduction to Python",
                Author = "Angie Yoon", Pages = 250,
                Rating = Rating.General,
                Genres = new List<Genre> {Genre.NonFiction, Genre.Comedy, Genre.Adventure, Genre.Fantasy}
            });

            /*var me = new Book
            {
                Isbn = 69, Title = "Introduction to Me",
                Author = "Abhay Sharma", Pages = 1250,
                Rating = Rating.Rated18,
                Genres = new List<Genre> {Genre.NonFiction, Genre.Action, Genre.Romance, Genre.SciFi}
            };
            nonFictionAo.Add(me);

            foreach (var bookInShelf in nonFictionAo) 
                Console.WriteLine(bookInShelf);

            nonFictionAo.Remove(me);
            Console.WriteLine();

            foreach (var bookInShelf in nonFictionAo)
                Console.WriteLine(bookInShelf);

            Console.WriteLine();
            Console.WriteLine(nonFictionAo.FindBookByTitle("Introduction to F#"));

            Console.WriteLine();
            nonFictionAo.FindBooksByAuthor("Angie Yoon").ForEach(Console.WriteLine);

            Console.WriteLine();
            nonFictionAo.FindBooksByGenre(Genre.Comedy).ForEach(Console.WriteLine);*/
        }
    }
}