namespace AbhaySharma.Library.Models
{
    public readonly struct AlphabetRange
    {
        public char Initial { get; }

        public char Final { get; }

        public AlphabetRange(char initial, char final) =>
            (Initial, Final) = (initial, final);

        public override string ToString() =>
            $"{Initial}-{Final}";
    }
}