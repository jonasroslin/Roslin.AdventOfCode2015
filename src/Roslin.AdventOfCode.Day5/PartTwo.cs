using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Roslin.AdventOfCode.Common;
using Roslin.AdventOfCode.Day5.Rules;

namespace Roslin.AdventOfCode.Day5
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_be_able_to_get_correct_number_of_nice_words()
        {
            var readInput = Input.Read("Roslin.AdventOfCode.Day5.input.txt", Assembly.GetExecutingAssembly()).ToList();

            var rules = new List<IRule>
            {
                new AnyPairAppearsAtLeastTwiceRule(),
                new AtLeastOneLetterWhichRepeatsWithExactlyOneLetterBetweenThemRule()
            };

            var checkIfWordIsNice = new CheckIfWordIsNice(rules);
            var numberOfNiceWords = readInput.Select(word => checkIfWordIsNice.IsNice(word)).Count(isNice => isNice);

            numberOfNiceWords.Should().Be(69);
        }

        [Test]
        public void Should_be_able_to_use_mulitple_inputs()
        {
            var readInput = new List<string> { "qjhvhtzxzqqjkmpb", "xxyxx", "uurcxstgmygtbstg", "ieodomkazucvgmuy" };

            var rules = new List<IRule>
            {
                new AnyPairAppearsAtLeastTwiceRule(),
                new AtLeastOneLetterWhichRepeatsWithExactlyOneLetterBetweenThemRule()
            };

            var checkIfWordIsNice = new CheckIfWordIsNice(rules);
            var numberOfNiceWords = readInput.Select(word => checkIfWordIsNice.IsNice(word)).Count(isNice => isNice);

            numberOfNiceWords.Should().Be(2);
        }

        [TestCase("qjhvhtzxzqqjkmpb", true)]
        [TestCase("xxyxx", true)]
        [TestCase("uurcxstgmygtbstg", false)]
        [TestCase("ieodomkazucvgmuy", false)]
        public void Should_be_able_to_combine_rules(string word, bool expected)
        {
            var rules = new List<IRule>
            {
                new AnyPairAppearsAtLeastTwiceRule(),
                new AtLeastOneLetterWhichRepeatsWithExactlyOneLetterBetweenThemRule()
            };

            var checkIfWordIsNice = new CheckIfWordIsNice(rules);
            var isNice = checkIfWordIsNice.IsNice(word);
            isNice.Should().Be(expected);
        }

        [Test]
        [TestCase("xyxy", true)]
        [TestCase("aabcdefgaa", true)]
        [TestCase("aaa", false)]
        [TestCase("aaaa", true)]
        public void Should_be_able_to_use_AnyPairAppearsAtLeastTwiceRule(string word, bool expected)
        {
            var rule = new AnyPairAppearsAtLeastTwiceRule();
            rule.IsNice(word).Should().Be(expected);
        }

        [Test]
        [TestCase("xyx", true)]
        [TestCase("abcdefeghi", true)]
        [TestCase("efe", true)]
        [TestCase("aaa", true)]
        [TestCase("abc", false)]
        public void Should_be_able_to_use_AtLeastOneLetterWhichRepeatsWithExactlyOneLetterBetweenThemRule(string word, bool expected)
        {
            var rule = new AtLeastOneLetterWhichRepeatsWithExactlyOneLetterBetweenThemRule();
            rule.IsNice(word).Should().Be(expected);
        }
    }
}