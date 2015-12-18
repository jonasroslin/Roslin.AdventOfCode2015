using System.Linq;

namespace Roslin.AdventOfCode.Day5.Rules
{
    public class AtLeastOneLetterWhichRepeatsWithExactlyOneLetterBetweenThemRule : IRule
    {
        public bool IsNice(string word)
        {
            var charArray = word.ToCharArray();
            for (var i = 0; charArray.Count() > i + 2; i++)
                if (charArray[i] == charArray[i + 2])
                    return true;

            return false;
        }
    }
}