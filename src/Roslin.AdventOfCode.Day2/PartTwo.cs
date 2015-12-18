using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Roslin.AdventOfCode.Common;

namespace Roslin.AdventOfCode.Day2
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_be_able_to_calculate_total_amout_of_ribbon_for_all_presents()
        {
            var allMeasurements = Input.Read("Roslin.AdventOfCode.Day2.input.txt", Assembly.GetExecutingAssembly()).ToList();
            var boxes = allMeasurements.Select(x => (PresentBox) x).ToList();

            var total = boxes.Sum(x => x.TotalAmountOfRibbon);
            total.Should().Be(3737498);
        }
    }
}