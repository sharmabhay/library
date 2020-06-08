using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AbhaySharma.Library.Models
{
    // 'sealed' makes sure you can't make subclasses
    public sealed class Book
    {
        [Key]
        public ulong Isbn { get; set; }

        [Required, StringLength(256, MinimumLength = 1)]
        public string Title { get; set; }

        [Required, StringLength(128, MinimumLength = 1)]
        public string Author { get; set; }

        [Required]
        public ushort Pages { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [Required]
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