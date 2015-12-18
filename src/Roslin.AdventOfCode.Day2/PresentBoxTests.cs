using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day2
{
    [TestFixture]
    public class PresentBoxTests
    {
        [Test]
        [TestCase("2x3x4", 34)]
        [TestCase("1x1x10", 14)]
        [TestCase("29x13x26", 9880)]
        public void Should_be_able_to_calculate_total_amout_of_ribbon(string condition, int exptected)
        {
            PresentBox presentBox = condition;
            presentBox.TotalAmountOfRibbon.Should().Be(exptected);
        }

        [Test]
        [TestCase("2x3x4", 58)]
        [TestCase("1x1x10", 43)]
        public void Can_calculate_paper_for_one_present(string condition, int exptected)
        {
            var presentBox = new PresentBox(condition);
            presentBox.TotalSizeOfPaper.Should().Be(exptected);
        }
    }
}