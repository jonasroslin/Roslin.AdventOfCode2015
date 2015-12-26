using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Roslin.AdventOfCode.Common;

namespace Roslin.AdventOfCode.Day8
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Shoul_be_able_to_count_santas_list()
        {
            var list = Input.Read("Roslin.AdventOfCode.Day8.input.txt", Assembly.GetExecutingAssembly()).ToList();

            var totalCode = list.Sum(SantasList.CodeCount);
            var totalCharacters = list.Sum(SantasList.CharactersCount);

            var result = totalCode - totalCharacters;

            result.Should().Be(1350);
        }
     }
}
