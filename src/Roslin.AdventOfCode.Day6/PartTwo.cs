using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day6
{
    [TestFixture]
    public class PartTwo
    {
        private int[,] _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new int[1000, 1000];
        }

        [Test]
        public void Should_be_able_to_follow_all_instructions()
        {
            var instructions = ReadInput();
            foreach (var instruction in instructions)
            {
                var instructionAction = new InstructionAction(instruction);
                ChangeGrid(instructionAction, _grid);
            }

            var calculateNumberOfLights = CalculateTotalBrightness(_grid);
            calculateNumberOfLights.Should().Be(14687245);
        }

        [Test]
        public void Should_be_able_to_follow_multiple_instructions()
        {
            var instructions = new List<string> {"turn on 0,0 through 0,0", "toggle 0,0 through 999,999", "turn off 0,0 through 0,0" };

            foreach (var instruction in instructions)
            {
                var instructionAction = new InstructionAction(instruction);
                ChangeGrid(instructionAction, _grid);
            }

            var calculateNumberOfLights = CalculateTotalBrightness(_grid);
            calculateNumberOfLights.Should().Be(2000000);
        }

        [Test]
        [TestCase("turn on 0,0 through 0,0", 1)]
        [TestCase("turn off 0,0 through 0,0", 0)]
        [TestCase("toggle 0,0 through 999,999", 2000000)]
        public void Foo(string instruction, int expected)
        {
            var instructionAction = new InstructionAction(instruction);
            ChangeGrid(instructionAction, _grid);
            CalculateTotalBrightness(_grid).Should().Be(expected);
        }

        private static void ChangeGrid(InstructionAction instruction, int[,] grid)
        {
            for (var i = instruction.FromX; i <= instruction.ToX; i++)
                for (var j = instruction.FromY; j <= instruction.ToY; j++)
                {
                    switch (instruction.Action)
                    {
                        case LightAction.TurnOn:
                            grid[i, j]++;
                            break;
                        case LightAction.TurnOff:
                        {
                            grid[i, j] -= 1;
                            if (grid[i, j] < 0)
                                grid[i, j] = 0;
                            break;
                        }
                        case LightAction.Toggle:
                            grid[i, j] += 2;
                            break;
                    }
                }
        }

        private static long CalculateTotalBrightness(int[,] grid)
        {
            long lights = 0;
            for (var i = 0; i < 1000; i++)
                for (var j = 0; j < 1000; j++)
                    lights += grid[i, j];

            return lights;
        }

        public IEnumerable<string> ReadInput()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Roslin.AdventOfCode.Day6.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}