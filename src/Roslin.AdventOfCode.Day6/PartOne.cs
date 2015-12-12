using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day6
{
    [TestFixture]
    public class PartOne
    {
        private bool[,] _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new bool[1000, 1000];
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

            var calculateNumberOfLights = CalculateNumberOfLights(_grid);
            calculateNumberOfLights.Should().Be(543903);
        }

        [Test]
        public void Should_be_able_to_toggle()
        {
            var instructionAction1 = new InstructionAction { Action = LightAction.TurnOn, FromX = 0, FromY = 0, ToX = 999, ToY = 999 };
            var instructionAction2 = new InstructionAction { Action = LightAction.Toggle, FromX = 499, FromY = 499, ToX = 500, ToY = 500 };
            ChangeGrid(instructionAction1, _grid);
            ChangeGrid(instructionAction2, _grid);

            var calculateNumberOfLights = CalculateNumberOfLights(_grid);
            calculateNumberOfLights.Should().Be(999996);
        }

        [Test]
        [TestCase("turn on 0,0 through 999,999", 1000000)]
        [TestCase("toggle 0,0 through 999,0", 1000)]
        [TestCase("turn off 499,499 through 500,500", 0)]
        public void Should_be_able_to_follow_instruction(string instruction, int expected)
        {
            var instructionAction = new InstructionAction(instruction);
            ChangeGrid(instructionAction, _grid);
            CalculateNumberOfLights(_grid).Should().Be(expected);
        }

        [Test]
        public void Should_be_able_to_translate_intructions()
        {
            const string instruction = "toggle 499,499 through 500,500";
            var intructionAction = new InstructionAction(instruction);

            intructionAction.Action.Should().Be(LightAction.Toggle);
            intructionAction.FromX.Should().Be(499);
            intructionAction.FromY.Should().Be(499);
            intructionAction.ToX.Should().Be(500);
            intructionAction.ToY.Should().Be(500);
        }

        [Test]
        [TestCase(0, 0, 999, 999, 1000000)]
        [TestCase(499, 499, 500, 500, 4)]
        [TestCase(0, 0, 999, 0, 1000)]
        public void Should_be_able_to_turnOn_lights(int fromX, int fromY, int toX, int toY, int result)
        {
            var instructionAction = new InstructionAction {Action = LightAction.TurnOn, FromX = fromX, FromY = fromY, ToX = toX, ToY = toY};
            ChangeGrid(instructionAction, _grid);

            var calculateNumberOfLights = CalculateNumberOfLights(_grid);
            calculateNumberOfLights.Should().Be(result);
        }

        private static void ChangeGrid(InstructionAction instruction, bool[,] grid) 
        {
            for (var i = instruction.FromX; i <= instruction.ToX; i++)
                for (var j = instruction.FromY; j <= instruction.ToY; j++)
                {
                    switch (instruction.Action)
                    {
                        case LightAction.TurnOn:
                            grid[i, j] = true;
                            break;
                        case LightAction.TurnOff:
                            grid[i, j] = false;
                            break;
                        case LightAction.Toggle:
                            grid[i, j] = !grid[i, j];
                            break;
                    }
                }
        }

        private static int CalculateNumberOfLights(bool[,] grid)
        {
            var lights = 0;
            for (var i = 0; i < 1000; i++)
                for (var j = 0; j < 1000; j++)
                    if (grid[i, j])
                        lights++;

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
