using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day2
{
    [TestFixture]
    public class PartTwo
    {
        private WrappingPaper _wrappingPaper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _wrappingPaper = new WrappingPaper();
        }

        [Test]
        [TestCase("2x3x4", 34)]
        [TestCase("1x1x10", 14)]
        [TestCase("29x13x26", 9880)]
        public void Should_be_able_to_calculate_total_amout_of_ribbon(string condition, int exptected)
        {
            _wrappingPaper.GetTheTotalAmountOfRibbon(condition).Should().Be(exptected);
        }

        [Test]
        public void Can_calculate_paper_for_mulitple_presents()
        {
            var measurements = new List<string> { "2x3x4", "1x1x10" };
            var total = _wrappingPaper.GetTheTotalAmountOfRibbonForAllMeasurements(measurements);
            total.Should().Be(48);
        }

        [Test]
        public void Should_be_able_to_calculate_total_amout_of_ribbon_for_all_presents()
        {
            var allMeasurements = _wrappingPaper.ReadInput().ToList();
            var total = _wrappingPaper.GetTheTotalAmountOfRibbonForAllMeasurements(allMeasurements);
            total.Should().Be(3737498);
        }
    }
}