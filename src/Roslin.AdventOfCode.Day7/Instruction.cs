using System;
using System.Linq;

namespace Roslin.AdventOfCode.Day7
{
    public class Instruction
    {
        public Gate Gate { get; set; }
        public string Result { get; set; }

        public static implicit operator Instruction(string instruction)
        {
            var strings = instruction.Split(new[] { " -> " }, StringSplitOptions.None);
            var opImplicit = new Instruction
            {
                Gate = strings.First(),
                Result = strings.Last(),
            };

            return opImplicit;
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