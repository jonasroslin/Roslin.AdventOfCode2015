using System.Collections.Generic;
using System.Linq;

namespace Roslin.AdventOfCode.Day5.Rules
{
    public class AnyPairAppearsAtLeastTwiceRule : IRule
    {
        public bool IsNice(string word)
        {
            var pairs = new List<string>();
            var charArray = word.ToCharArray();
            var lastPair = string.Empty;
            var skippedOne = false;

            for (var i = 0; charArray.Length > i + 1; i++)
            {
                var item = charArray[i].ToString() + charArray[i + 1];
                if (item != lastPair || skippedOne)
                {
                    skippedOne = false;
                    pairs.Add(item);
                }
                else
                    skippedOne = true;

                lastPair = item;
            }

            return pairs.Distinct().Count() < pairs.Count;
        }
    }
}