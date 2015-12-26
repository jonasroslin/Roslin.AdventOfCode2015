using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Roslin.AdventOfCode.Common;

namespace Roslin.AdventOfCode.Day8
{
    [TestFixture]
    public class SantasListTests
    {
        private List<string> _list;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _list = Input.Read("Roslin.AdventOfCode.Day8.testcase.txt", Assembly.GetExecutingAssembly()).ToList();
        }

        [Test]
        [TestCase(0, 2)]
        [TestCase(1, 5)]
        [TestCase(2, 10)]
        [TestCase(3, 6)]
        public void Should_be_able_to_count_characters_of_code(int index, int expected)
        {
            SantasList.CodeCount(_list[index]).Should().Be(expected);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 3)]
        [TestCase(2, 7)]
        [TestCase(3, 1)]
        public void Should_be_able_to_count_characters(int index, int expected)
        {
            SantasList.CharactersCount(_list[index]).Should().Be(expected);
        }
    }
}