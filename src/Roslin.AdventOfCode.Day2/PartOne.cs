using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day2
{
    [TestFixture]
    public class PartOne
    {
        private WrappingPaper _wrappingPaper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _wrappingPaper = new WrappingPaper();
        }

        [Test]
        public void Can_calculate_paper_for_all_presents()
        {
            var allMeasurements = _wrappingPaper.ReadInput().ToList();
            var total = _wrappingPaper.GetTheTotalSizeOfNeededPaperForAllMeasurements(allMeasurements);
            total.Should().Be(1586300);
        }

        [Test]
        public void Can_calculate_paper_for_mulitple_presents()
        {
            var measurements = new List<string> { "2x3x4", "1x1x10" };
            var total = _wrappingPaper.GetTheTotalSizeOfNeededPaperForAllMeasurements(measurements);
            total.Should().Be(101);
        }

        [Test]
        [TestCase("2x3x4", 58)]
        [TestCase("1x1x10", 43)]
        public void Can_calculate_paper_for_one_present(string condition, int exptected)
        {
            var size = _wrappingPaper.GetTheTotalSizeOfNeededPaper(condition);
            size.Should().Be(exptected);
        }
    }
}
