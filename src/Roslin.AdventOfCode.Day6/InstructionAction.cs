using System;
using System.Linq;

namespace Roslin.AdventOfCode.Day6
{
    public class InstructionAction
    {
        public int FromX { get; set; }
        public int FromY { get; set; }
        public int ToX { get; set; }
        public int ToY { get; set; }
        public LightAction Action { get; set; }

        public InstructionAction()
        {}

        public InstructionAction(string instruction)
        {
            if (instruction.StartsWith("toggle"))
            {
                SetAction("toggle");
                instruction = instruction.Replace("toggle ", string.Empty);
            }
            if (instruction.StartsWith("turn on"))
            {
                SetAction("turn on");
                instruction = instruction.Replace("turn on ", string.Empty);
            }
            if (instruction.StartsWith("turn off"))
            {
                SetAction("turn off");
                instruction = instruction.Replace("turn off ", string.Empty);
            }

            var strings = instruction.Split(' ');
            var split = strings[0].Split(',');
            FromX = Convert.ToInt32(split[0]);
            FromY = Convert.ToInt32(split[1]);

            var strings1 = strings.Last().Split(',');
            ToX = Convert.ToInt32(strings1[0]);
            ToY = Convert.ToInt32(strings1[1]);
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
}