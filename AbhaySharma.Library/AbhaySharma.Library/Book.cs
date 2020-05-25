namespace AbhaySharma.Library
{
    public sealed class Book
    {
        public ulong Isbn { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public ushort Pages { get; set; }

        public Genre Genre { get; set; }

        public Rating Rating { get; set; }

        public override string ToString() =>
            $"{Isbn}\n{Title}\n{Author}\n{Pages}\n{Genre}\n{Rating}";
    }
}