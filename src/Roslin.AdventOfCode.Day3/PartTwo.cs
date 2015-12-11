//using System.Collections.Generic;
//using System.Linq;
//using FluentAssertions;
//using NUnit.Framework;

//namespace Roslin.AdventOfCode.Day3
//{
//    [TestFixture]
//    public class PartTwo
//    {
//        [Test]
//        [TestCase("^v", 3)]
//        [TestCase("^>v<", 3)]
//        [TestCase("^v^v^v^v^v", 11)]
//        public void Should_be_able_to_count_unique_houses(string condition, int expected)
//        {
//            var count = CountNumberOfUniqueHouses(condition);
//            count.Should().Be(expected);
//        }

//        private static int CountNumberOfUniqueHouses(string condition)
//        {
//            var nodes = new List<Node>();
//            var start = new Node(0, 0);
//            nodes.Add(start);

//            var current = new Node(start.X, start.Y);
//            var charArray = condition.ToCharArray();
//            foreach (var step in charArray)
//            {
//                switch (step)
//                {
//                    case '>':
//                    {
//                        var node = new Node(current.X + 1, current.Y);
//                        nodes.Add(node);
//                        current = new Node(node.X, node.Y);
//                        continue;
//                    }
//                    case '<':
//                    {
//                        var node = new Node(current.X - 1, current.Y);
//                        nodes.Add(node);
//                        current = new Node(node.X, node.Y);
//                        continue;
//                    }
//                    case '^':
//                    {
//                        var node = new Node(current.X, current.Y + 1);
//                        nodes.Add(node);
//                        current = new Node(node.X, node.Y);
//                        continue;
//                    }
//                    case 'v':
//                    {
//                        var node = new Node(current.X, current.Y - 1);
//                        nodes.Add(node);
//                        current = new Node(node.X, node.Y);
//                        continue;
//                    }
//                }
//            }

//            var count = nodes.Select(x => x.HashCode()).Distinct().Count();
//            return count;
//        }
//    }
//}