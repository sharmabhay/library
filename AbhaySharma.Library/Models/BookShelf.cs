using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AbhaySharma.Library.Models
{
    public sealed class BookShelf : IEnumerable<Book>
    {
        private List<Book> _books = new List<Book>();

        public ushort Number { get; set; }

        public AlphabetRange AlphabetRange { get; set; }

        public Genre Genre { get; set; }

        public void Add(Book book)
        {
            if (book == null) 
                throw new ArgumentNullException(nameof(book));
            if (book.Title.ToLower()[0] < char.ToLower(AlphabetRange.Initial)
                || book.Title.ToLower()[0] > char.ToLower(AlphabetRange.Final))
                throw new ArgumentOutOfRangeException(nameof(book.Title));
            if (!book.Genres.Contains(Genre))
                throw new ArgumentException(nameof(book.Genres));

            _books.Add(book);
        }

        public void Remove(Book book)
        {
            if (book == null) 
                throw new ArgumentNullException(nameof(book));

            _books.Remove(book);
        }

        public Book FindBookByTitle(string bookTitle) =>
            _books.Single(book =>
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
            _books.Where(book =>
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
            _books.Where(book => book.Genres.Contains(bookGenre)).ToList();

        public IEnumerator<Book> GetEnumerator() =>
            _books.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}