namespace Roslin.AdventOfCode.Day5.Rules
{
    public class AtLeastOneLetterThatAppearsTwiceRule : IRule
    {
        public bool IsNice(string word)
        {
            var charArray = word.ToCharArray();

            for (var i = 0; charArray.Length > i +1; i++)
            {
                if (charArray[i] == charArray[i + 1])
                    return true;
            }
            return false;
        }
    }
}