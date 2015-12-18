using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day2
{
    [TestFixture]
    public class When_creating_present_box
    {
        private PresentBox _presentBox;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _presentBox = "2x3x4";
        }

        [Test]
        public void Length_should_be_set()
        {
            _presentBox.Length.Should().Be(2);
        }

        [Test]
        public void Width_should_be_set()
        {
            _presentBox.Width.Should().Be(3);
        }

        [Test]
        public void Height_should_be_set()
        {
            _presentBox.Height.Should().Be(4);
        }
    }
}