using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day1
{
    [TestFixture]
    public class ApartmentBuildingTests
    {
        [Test]
        [TestCase(")", 1)]
        [TestCase("()())", 5)]
        public void Should_be_able_to_find_when_santa_is_entering_the_basement(string input, int expected)
        {
            var numberOfSteps = ApartmentBuilding.FindWhenSantaIsEnteringTheBasement(input);
            numberOfSteps.Should().Be(expected);
        }

        [Test]
        [TestCase("(())", 0)]
        [TestCase("()()", 0)]
        [TestCase("(((", 3)]
        [TestCase("(()(()(", 3)]
        [TestCase("))(((((", 3)]
        [TestCase("())", -1)]
        [TestCase("))(", -1)]
        [TestCase(")))", -3)]
        [TestCase(")())())", -3)]
        public void Should_end_on_correct_floor(string input, int expected)
        {
            var endingFloor = ApartmentBuilding.CalculateEndingFloor(input);
            endingFloor.Should().Be(expected);
        }
    }
}