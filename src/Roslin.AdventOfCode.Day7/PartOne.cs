using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Roslin.AdventOfCode.Common;

namespace Roslin.AdventOfCode.Day7
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        [TestCase("x AND y -> d", null)]
        [TestCase("123 -> x", 123)]
        public void Try_to_find_result(string instruction, int? expected)
        {
            Instruction i = instruction;

            var result = i.CalculateResult();
            result.Should().Be(expected);
        }

        [Test]
        public void Should_be_able_to_create_gate()
        {
            Gate gate = "x AND y";

            gate.Action.Should().Be(InstructionAction.And);
            gate.X.Should().Be("x");
            gate.Y.Should().Be("y");
        }

        [Test]
        [TestCase("123", 123)]
        [TestCase("123 AND 456", 72)]
        [TestCase("123 OR 456", 507)]
        [TestCase("123 LSHIFT 2", 492)]
        [TestCase("456 RSHIFT 2", 114)]
        [TestCase("NOT 123", 65412)]
        [TestCase("NOT 456", 65079)]
        [TestCase("x AND 456", null)]
        public void Should_be_able_to_get_result_from_gate(string condition, int? expected)
        {
            Gate ls = condition;
            ls.Result.Should().Be(expected);
        }

        [Test]
        public void Should_be_able_to_get_result_from_instruction()
        {
            Instruction instruction = "x AND y -> d";
            instruction.Result.Should().Be("d");
        }

        [Test]
        public void Should_be_able_to_find_signal_on_given_wire()
        {
            var instructions = new List<Instruction>
            {
                "123 -> x",
                "NOT x -> h",
            };

            var wireCircuit = new WireCircuit { Instructions = instructions };
            wireCircuit.SendSignalsUntilGivenGateIsCompleted("h");

            wireCircuit.UltimatelySignals["h"].Should().Be(65412);
        }

        [Test]
        public void Should_be_able_to_follow_all_instructions()
        {
            var readInput = Input.Read("Roslin.AdventOfCode.Day7.input.txt", Assembly.GetExecutingAssembly()).ToList();
            var instructions = readInput.Select(input => (Instruction) input).ToList();

            var wireCircuit = new WireCircuit { Instructions = instructions };
            wireCircuit.SendSignalsUntilGivenGateIsCompleted("a");
            wireCircuit.UltimatelySignals["a"].Should().Be(46065);
        }
    }
}
