using System.Collections.Generic;

namespace Roslin.AdventOfCode.Day7
{
    public class WireCircuit
    {
        public Dictionary<string, int> UltimatelySignals { get; set; }
        public List<Instruction> Instructions { get; set; }

        public void SendSignalsUntilGivenGateIsCompleted(string gate)
        {
            UltimatelySignals.Clear();
            while (!UltimatelySignals.ContainsKey(gate))
            {
                foreach (var instruction in Instructions)
                {
                    var result = instruction.CalculateResult();

                    if (result.HasValue)
                    {
                        var last = instruction.Result;
                        if (UltimatelySignals.ContainsKey(last))
                            UltimatelySignals[last] = result.Value;
                        else
                            UltimatelySignals.Add(last, result.Value);
                    }
                }

                foreach (var ultimatelySignal in UltimatelySignals)
                {
                    foreach (var instruction in Instructions)
                    {
                        if (instruction.Gate.X != null)
                            if (instruction.Gate.X == ultimatelySignal.Key)
                                instruction.Gate.X = ultimatelySignal.Value.ToString();

                        if (instruction.Gate.Y != null)
                            if (instruction.Gate.Y == ultimatelySignal.Key)
                                instruction.Gate.Y = ultimatelySignal.Value.ToString();
                    }
                }
            }
        }

        public WireCircuit()
        {
            UltimatelySignals = new Dictionary<string, int>();
        }
    }
}