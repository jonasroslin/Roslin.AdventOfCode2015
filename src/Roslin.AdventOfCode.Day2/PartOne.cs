using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day2
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Can_calculate_paper_for_mulitple_presents()
        {
            var presents = new List<string> { "2x3x4", "1x1x10" };

            var total = presents.Aggregate<string, double>(0, (current, measurements) => current + GetTheTotalSizeOfNeededPaper(measurements));

            total.Should().Be(101);
        }

        [Test]
        [TestCase("2x3x4", 58)]
        [TestCase("1x1x10", 43)]
        public void Foo(string condition, int exptected)
        {
            var d = GetTheTotalSizeOfNeededPaper(condition);

            d.Should().Be(exptected);
        }

        private static double GetTheTotalSizeOfNeededPaper(string condition)
        {
            var sides = condition.Split('x');
            var presentBox = new PresentBox
            {
                Lenght = Convert.ToInt32(sides[0]),
                Width = Convert.ToInt32(sides[1]),
                Hight = Convert.ToInt32(sides[2])
            };

            var totalSizeOfThePaper = presentBox.Surface + presentBox.SmallesSide;
            return totalSizeOfThePaper;
        }
    }

    public class PresentBox
    {
        public double Lenght { get; set; }
        public double Width { get; set; }
        public double Hight { get; set; }
        public double Surface => (2*Lenght*Width) + (2*Width*Hight) + (2*Hight*Lenght);

        public double SmallesSide
        {
            get
            {
                var sides = new List<double> {(Lenght*Width), (Width*Hight), (Hight*Lenght)};
                return sides.Min();
            }
        }
    }
}
