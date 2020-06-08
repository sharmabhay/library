using System;

namespace AbhaySharma.Library.Models
{
    public readonly struct AlphabetRange
    {
        public char Initial { get; }

        public char Final { get; }

        public AlphabetRange(char initial, char final) =>
            (Initial, Final) = (char.ToUpper(initial), char.ToUpper(final));

        public override string ToString() =>
            $"{Initial}-{Final}";

        internal static AlphabetRange ParseAlphabetRange(string alphabetRangeString)
        {
            var split = alphabetRangeString.Split('-', StringSplitOptions.RemoveEmptyEntries);
            return new AlphabetRange(split[0][0], split[1][0]);
        }
    }
}