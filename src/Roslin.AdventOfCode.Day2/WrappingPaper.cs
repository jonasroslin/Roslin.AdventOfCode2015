using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Roslin.AdventOfCode.Day2
{
    public class WrappingPaper
    {
        public IEnumerable<string> ReadInput()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Roslin.AdventOfCode.Day2.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }

        public int GetTheTotalAmountOfRibbon(string condition)
        {
            var sides = condition.Split('x');

            var presentBox = new PresentBox
            {
                Lenght = Convert.ToInt32(sides[0]),
                Width = Convert.ToInt32(sides[1]),
                Hight = Convert.ToInt32(sides[2])
            };

            return presentBox.TotalAmountOfRibbon;
        }

        public int GetTheTotalAmountOfRibbonForAllMeasurements(List<string> conditions)
        {
            return conditions.Aggregate<string, int>(0, (current, condition) => current + GetTheTotalAmountOfRibbon(condition));
        }

        public double GetTheTotalSizeOfNeededPaper(string condition)
        {
            var sides = condition.Split('x');
            var presentBox = new PresentBox
            {
                Lenght = Convert.ToInt32(sides[0]),
                Width = Convert.ToInt32(sides[1]),
                Hight = Convert.ToInt32(sides[2])
            };

            return presentBox.TotalSizeOfPaper;
        }

        public double GetTheTotalSizeOfNeededPaperForAllMeasurements(List<string> conditions)
        {
            return conditions.Aggregate<string, double>(0, (current, condition) => current + GetTheTotalSizeOfNeededPaper(condition));
        }
    }
}