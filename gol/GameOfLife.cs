using System;
using System.Collections.Generic;
using System.Linq;

namespace gol
{
    public class GameOfLife
    {
        public static string Render(List<Cell> cells)
        {
            var largestX = cells.Max(c => c.X);
            var largestY = cells.Max(c => c.Y);
            Func<int,int,bool, string> buildCell = (x,y,on) => 
                string.Format("<div class=\"cell {2}\" style=\"left: {0}px; top: {1}px;\">&nbsp;</div>", 20 * (x+1), 20 * (y+1), @on ? "on" : "");

            var results = from x in Enumerable.Range(0, largestX+1)
                          from y in Enumerable.Range(0, largestY+1)
                          select buildCell(x, y, IsOn(cells, x, y));
            return string.Join("\n", results);
        }

        private static bool IsOn(IEnumerable<Cell> cells, int x, int y)
        {
            return cells.Any(c => c.X == x && c.Y == y);
        }
    }

    public struct Cell
    {
        public int X;
        public int Y;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
