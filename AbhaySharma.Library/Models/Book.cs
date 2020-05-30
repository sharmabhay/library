using System.Collections.Generic;
using System.Linq;

namespace AbhaySharma.Library.Models
{
    public sealed class Book
    {
        public ulong Isbn { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public ushort Pages { get; set; }

        public Rating Rating { get; set; }

        public List<Genre> Genres { get; set; }

        public override string ToString() =>
            $"{Isbn}\n{Title}\n{Author}\n{Pages}\n{Rating}\n" +
                Genres.Select(ConvertGenreToString).Aggregate(AddStrings);

        // selects an enum Genre and converts it to a string ToString
        private static string ConvertGenreToString(Genre g) =>
            g.ToString();

        // concatenates the strings together with an '&' in between
        private static string AddStrings(string a, string c) =>
            $"{a} & {c}";
    }
}