using System;

namespace AbhaySharma.Library
{
    public static class Program
    {
        public static void Main()
        {
            var book = new Book
            {
                Isbn = 1, Title = "Introduction to C#",
                Author = "Rajat Patwari", Pages = 350, Genre = Genre.NonFiction,
                Rating = Rating.ParentalGuidance13
            };
            Console.WriteLine(book);
        }
    }
}