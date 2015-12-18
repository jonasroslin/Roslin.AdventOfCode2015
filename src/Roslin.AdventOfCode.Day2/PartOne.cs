using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Roslin.AdventOfCode.Common;

namespace Roslin.AdventOfCode.Day2
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Can_calculate_paper_for_all_presents()
        {
            var allMeasurements = Input.Read("Roslin.AdventOfCode.Day2.input.txt", Assembly.GetExecutingAssembly()).ToList();
            var boxes = allMeasurements.Select(x => (PresentBox)x).ToList();

            var total = boxes.Sum(x => x.TotalSizeOfPaper);
            total.Should().Be(1586300);
        }
    }
}
