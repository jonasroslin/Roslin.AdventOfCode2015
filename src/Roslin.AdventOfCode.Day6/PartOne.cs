using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day6
{
    public enum LightAction
    {
        TurnOn, TurnOff, Toggle
    }

    public class InstructionAction
    {
        public int FromX { get; set; }
        public int FromY { get; set; }
        public int ToX { get; set; }
        public int ToY { get; set; }
        public LightAction Action { get; set; }

        public InstructionAction(string intruction)
        {
            var strings = intruction.Split(' ');
            SetAction(strings[0]);
        }

        public void SetAction(string action)
        {
            switch (action)
            {
                case "toggle":
                    Action = LightAction.Toggle;
                    break;
                case "turn on":
                    Action = LightAction.TurnOn;
                    break;
                case "turn off":
                    Action = LightAction.TurnOff;
                    break;
            }
        }
    }

    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Foo()
        {
            bool[,] grid = new bool[1000, 1000];
            grid[300, 200] = true;
            var b = grid[300, 200];
        }

        [Test]
        public void Should_be_able_to_translate_intructions()
        {
            var instruction = "toggle 461,550 through 564,900";
            var intructionAction = new InstructionAction(instruction);

        }

        [Test]
        [TestCase(0, 0, 999, 999, 1000000)]
        [TestCase(499, 499, 500, 500, 4)]
        [TestCase(0, 0, 999, 0, 1000)]
        public void Should_be_able_to_turnOn_lights(int fromX, int fromY, int toX, int toY, int result)
        {
            var grid = new bool[1000, 1000];

            ChangeGrid(fromX, fromY, toX, toY, grid, LightAction.TurnOn);

            var calculateNumberOfLights = CalculateNumberOfLights(grid);
            calculateNumberOfLights.Should().Be(result);
        }

        private static void ChangeGrid(int fromX, int fromY, int toX, int toY, bool[,] grid, LightAction action)
        {
            for (var i = fromX; i <= toX; i++)
                for (var j = fromY; j <= toY; j++)
                {
                    switch (action)
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
    }
}
