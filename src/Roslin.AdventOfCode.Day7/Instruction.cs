using System;
using System.Linq;

namespace Roslin.AdventOfCode.Day7
{
    public class Instruction
    {
        public Gate Gate { get; }
        public string Result { get; }

        public static implicit operator Instruction(string instruction)
        {
            var instructionParts = instruction.Split(new[] { " -> " }, StringSplitOptions.None);
            return new Instruction(instructionParts.First(), instructionParts.Last());
        }

        private Instruction(Gate gate, string result)
        {
            Gate = gate;
            Result = result;
        }

        public int? CalculateResult()
        {
            return Gate.Result;
        }

        public override string ToString()
        {
            return $"{Gate.X} {Gate.Action} {Gate.Y} -> {Result}";
        }
    }
}