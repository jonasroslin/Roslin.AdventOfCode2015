using System.Linq;

namespace Roslin.AdventOfCode.Day1
{
    public static class ApartmentBuilding
    {
        public static int CalculateEndingFloor(string input)
        {
            var charArray = input.ToCharArray();
            var down = charArray.Where(x => x == ')').Count();
            var up = charArray.Where(x => x == '(').Count();
            return up - down;
        }

        public static int FindWhenSantaIsEnteringTheBasement(string input)
        {
            var start = 0;
            var numberOfSteps = 0;
            foreach (var step in input.ToCharArray())
            {
                numberOfSteps++;
                if (step == ')')
                    start--;
                else
                    start++;

                if (start < 0)
                    break;
            }

            return numberOfSteps;
        }
    }
}