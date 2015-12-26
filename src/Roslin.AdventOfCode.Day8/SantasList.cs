using System.Text.RegularExpressions;

namespace Roslin.AdventOfCode.Day8
{
    public static class SantasList
    {
        public static int CharactersCount(string s)
        {
            var match = Regex.Match(s, PatternForStringLiteral());
            return match.Groups[1].Captures.Count;
        }

        public static int CodeCount(string s)
        {
            return s.Length;
        }

        private static string PatternForStringLiteral()
        {
            return @"^""(\\x..|\\.|.)*""$";
        }
    }
}