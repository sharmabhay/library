namespace AbhaySharma.Library
{
    public readonly struct AlphabetRange
    {
        public char Initial { get; }

        public char Final { get; }

        public AlphabetRange(char initial, char final) =>
            (Initial, Final) = (initial, final);
    }
}