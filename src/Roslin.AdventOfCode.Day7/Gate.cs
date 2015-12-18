using System;

namespace Roslin.AdventOfCode.Day7
{
    public class Gate
    {
        //x [action] y
        public string X { get; set; }
        public string Y { get; set; }
        public InstructionAction Action { get; set; }

        public int? Result
        {
            get
            {
                if (X == null && IsInt(Y))
                    return 65535 - Convert.ToInt32(Y);

                if (IsInt(X) && Y == null)
                    return Convert.ToInt32(X);

                if (!IsInt(X) || !IsInt(Y)) return null;

                switch (Action)
                {
                    case InstructionAction.And:
                        return Convert.ToInt32(X) & Convert.ToInt32(Y);
                    case InstructionAction.Lshift:
                        return Convert.ToInt32(X) << Convert.ToInt32(Y);
                    case InstructionAction.Rshift:
                        return Convert.ToInt32(X) >> Convert.ToInt32(Y);
                    case InstructionAction.Or:
                        return Convert.ToInt32(X) | Convert.ToInt32(Y);
                    default:
                        return null;
                }
            }
        }

        public bool IsInt(string s)
        {
            int result;
            return int.TryParse(s, out result);
        }

        public static implicit operator Gate(string operation)
        {
            var strings = operation.Split(' ');
            if (strings.Length == 3)
            {
                var gate = new Gate
                {
                    X = strings[0],
                    Y = strings[2],
                };

                var s = strings[1];
                InstructionAction action;
                switch (s)
                {
                    case "AND":
                        action = InstructionAction.And;
                        break;
                    case "OR":
                        action = InstructionAction.Or;
                        break;
                    case "LSHIFT":
                        action = InstructionAction.Lshift;
                        break;
                    case "RSHIFT":
                        action = InstructionAction.Rshift;
                        break;
                    default:
                        action = InstructionAction.Unknown;
                        break;
                }

                gate.Action = action;
                return gate;
            }

            return strings.Length == 1 
                ? new Gate { X = strings[0], Action = InstructionAction.Assign } 
                : new Gate { Action = InstructionAction.Not, Y = strings[1] };
        }
    }
}