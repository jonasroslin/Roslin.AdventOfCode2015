using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day5
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_be_able_to_get_correct_number_of_nice_words()
        {
            var readInput = ReadInput();
            var checkIfWordIsNice = new CheckIfWordIsNice(new List<IRule> { new VowelsRule(), new AtLeastOneLetterThatAppearsTwiceRule() });
            var numberOfNiceWords = readInput.Select(word => checkIfWordIsNice.IsNice(word, new ConstantRule())).Count(isNice => isNice);

            numberOfNiceWords.Should().Be(238);
        }

        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("aaa", true)]
        [TestCase("jchzalrnumimnmhp", false)]
        [TestCase("haegwjzuvuyypxyu", false)]
        [TestCase("dvszwmarrgswjxmb", false)]
        public void Should_be_able_to_combine_rules(string word, bool expected)
        {
            var checkIfWordIsNice = new CheckIfWordIsNice(new List<IRule> {new VowelsRule(), new AtLeastOneLetterThatAppearsTwiceRule()});
            var isNice = checkIfWordIsNice.IsNice(word, new ConstantRule());
            isNice.Should().Be(expected);
        }

        [Test]
        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("abcd", false)]
        public void Should_be_able_to_use_VowelsRule(string word, bool expected)
        {
            var rule = new VowelsRule();
            rule.IsNice(word).Should().Be(expected);
        }

        [Test]
        [TestCase("abcdde", true)]
        [TestCase("abcded", false)]
        [TestCase("abcdefghij", false)]
        public void Should_be_able_to_use_AtLeastOneLetterThatAppearsTwiceRule(string word, bool expected)
        {
            var rule = new AtLeastOneLetterThatAppearsTwiceRule();
            rule.IsNice(word).Should().Be(expected);
        }

        [Test]
        [TestCase("haegwjzuvuyypxyu", false)]
        [TestCase("acefghij", true)]
        public void Should_be_able_to_use_ConstantRule(string word, bool expected)
        {
            var rule = new ConstantRule();
            rule.IsNice(word).Should().Be(expected);
        }

        public IEnumerable<string> ReadInput()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Roslin.AdventOfCode.Day5.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
