using System.Linq;

namespace Roslin.AdventOfCode.Day5
{
    public class VowelsRule : IRule
    {
        public bool IsNice(string word)
        {
            var charArray = word.ToCharArray();
            var numberOfVowels = charArray.Where(x => x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u').Count();
            return numberOfVowels >= 3;
        }
    }
}