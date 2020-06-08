using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AbhaySharma.Library.Models
{
    public sealed class BookShelf : IEnumerable<Book>
    {
        [Key]
        public ushort Number { get; set; }

        [Required]
        public AlphabetRange AlphabetRange { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public List<Book> Books { get; set; } = new List<Book>();

        public void Add(Book book)
        {
            if (book == null) 
                throw new ArgumentNullException(nameof(book));
            if (book.Title.ToLower()[0] < char.ToLower(AlphabetRange.Initial)
                || book.Title.ToLower()[0] > char.ToLower(AlphabetRange.Final))
                throw new ArgumentOutOfRangeException(nameof(book.Title));
            if (!book.Genres.Contains(Genre))
                throw new ArgumentException(nameof(book.Genres));

            Books.Add(book);
        }

        public void Remove(Book book)
        {
            if (book == null) 
                throw new ArgumentNullException(nameof(book));

            Books.Remove(book);
        }

        public Book FindBookByTitle(string bookTitle) =>
            Books.Single(book =>
                book.Title == (bookTitle ?? throw new ArgumentNullException(nameof(bookTitle))));
        /*
         Same Code as:
            if (bookTitle == null) 
                throw new ArgumentNullException(nameof(bookTitle));

            foreach (var book in _books) 
                if (book.Title == bookTitle) return book;

            throw new ArgumentException(nameof(bookTitle));
        */

        public List<Book> FindBooksByAuthor(string bookAuthor) =>
            Books.Where(book =>
                book.Author == (bookAuthor ?? throw new ArgumentNullException(nameof(bookAuthor)))).ToList();
        /*
         Same Code as:
            if (bookAuthor == null) 
                throw new ArgumentNullException(nameof(bookAuthor));

            var sameAuthor = new List<Book>();
            foreach (var book in _books)
                if (book.Author == bookAuthor) sameAuthor.Add(book);
            return sameAuthor;
        */

        public List<Book> FindBooksByGenre(Genre bookGenre) =>
            Books.Where(book => book.Genres.Contains(bookGenre)).ToList();

        public IEnumerator<Book> GetEnumerator() =>
            Books.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}