namespace Roslin.AdventOfCode.Day5.Rules
{
    public class ConstantRule : IRule
    {
        public bool IsNice(string word)
        {
            return !(word.Contains("ab") || word.Contains("cd") || word.Contains("pq") || word.Contains("xy"));
        }
    }
}