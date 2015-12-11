using System.Collections.Generic;
using System.Linq;

namespace Roslin.AdventOfCode.Day2
{
    public class PresentBox
    {
        public int Lenght { get; set; }
        public int Width { get; set; }
        public int Hight { get; set; }
        public int Surface => (2*Lenght*Width) + (2*Width*Hight) + (2*Hight*Lenght);

        public int SmallesSide
        {
            get
            {
                var sides = new List<int> {(Lenght*Width), (Width*Hight), (Hight*Lenght)};
                return sides.Min();
            }
        }

        public int TotalSizeOfPaper
        {
            get { return Surface + SmallesSide; }
        }

        public int TotalAmountOfRibbon
        {
            get
            {
                var ints = new List<int> {Lenght, Width, Hight };
                var orderedEnumerable = ints.OrderBy(x => x).ToList();
                var i = orderedEnumerable[0] + orderedEnumerable[0] + orderedEnumerable[1] + orderedEnumerable[1];

                var i1 = Lenght * Width * Hight;

                var i2 = i + i1;

                return i2;
            }
        }

    }
}