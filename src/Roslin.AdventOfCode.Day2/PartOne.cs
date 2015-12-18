using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day2
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Can_calculate_paper_for_all_presents()
        {
            var allMeasurements = ReadInput().ToList();
            var boxes = allMeasurements.Select(x => (PresentBox)x).ToList();

            var total = boxes.Sum(x => x.TotalSizeOfPaper);
            total.Should().Be(1586300);
        }

        public IEnumerable<string> ReadInput()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Roslin.AdventOfCode.Day2.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
