using System;
using System.Collections.Generic;
using System.Linq;

namespace Roslin.AdventOfCode.Day2
{
    public class PresentBox
    {
        public int Length { get; }
        public int Width { get; }
        public int Height { get; }

        private int Surface => 2 * Length * Width + 2 * Width * Height + 2 * Height * Length;

        private int SmallestSide
        {
            get
            {
                var sides = new List<int> { Length * Width, Width * Height, Height * Length };
                return sides.Min();
            }
        }

        public int TotalSizeOfPaper => Surface + SmallestSide;

        public int TotalAmountOfRibbon
        {
            get
            {
                var readings = new List<int> { Length, Width, Height };
                var readingsInOrder = readings.OrderBy(x => x).ToList();

                var presentRibbon = readingsInOrder[0] + readingsInOrder[0] + readingsInOrder[1] + readingsInOrder[1];
                var ribbonForTheBow = Length * Width * Height;

                return presentRibbon + ribbonForTheBow;
            }
        }

        public static implicit operator PresentBox(string input)
        {
            return new PresentBox(input);
        }

        public PresentBox(string input)
        {
            var sides = input.Split('x');

            Length = Convert.ToInt16(sides[0]);
            Width = Convert.ToInt16(sides[1]);
            Height = Convert.ToInt16(sides[2]);
        }
    }
}