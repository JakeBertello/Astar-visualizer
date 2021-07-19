using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace astar
{
    class Astar
    {
        Cell curr;
        
        public int G { get; set; }
        public void search(Grid grid)
        {
            curr = null;
            var start = grid.cellAt(grid.Start[1], grid.Start[0]);
            var target = grid.cellAt(grid.Target[1], grid.Target[0]);
            var openList = new List<Cell>();
            var closedList = new List<Cell>();
            int g = 0;

            openList.Add(start);

            while (openList.Count > 0)
            {
                var lowestF = openList.Min(l => l.F);
                curr = openList.First(l => l.F == lowestF);

                closedList.Add(curr);
                openList.Remove(curr);
                curr.setCellType(Cell.CellType.Searched);

                if (closedList.FirstOrDefault(l => l.X == target.X && l.Y == target.Y) != null))
                        break;

                var adjacentSquares = grid.getWalkableAdjacentSquares(curr.X, curr.Y);

                foreach(var adjacentSquare in adjacentSquares)
                {
                    if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) == null)
                    {
                        adjacentSquare.G = g;
                        adjacentSquare.H = adjacentSquare.compH(adjacentSquare.X, adjacentSquare.Y, target.X, target.Y);
                        adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                        adjacentSquare.parent = curr;
                        openList.Insert(0, adjacentSquare);
                    }
                }
            }
        }
    }
}
