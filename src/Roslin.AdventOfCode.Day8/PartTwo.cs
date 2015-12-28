using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Roslin.AdventOfCode.Common;

namespace Roslin.AdventOfCode.Day8
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Shoul_be_able_to_count_santas_list()
        {
            var list = Input.Read("Roslin.AdventOfCode.Day8.input.txt", Assembly.GetExecutingAssembly()).ToList();

            var totalCode = list.Sum(SantasList.CodeCount);
            var totalEncoded = list.Sum(SantasList.CountEncodedCharacters);

            var result = totalEncoded - totalCode;

            result.Should().Be(2085);
        }

    }
}