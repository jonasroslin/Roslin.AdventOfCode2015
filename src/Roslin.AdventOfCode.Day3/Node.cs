namespace Roslin.AdventOfCode.Day3
{
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string HashCode()
        {
            return $"x{X}y{Y}";
        }
    }
}