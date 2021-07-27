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
            var start = grid.cellAt(grid.Start[0], grid.Start[1]);
            var target = grid.cellAt(grid.Target[0], grid.Target[1]);
            var openList = new List<Cell>();
            var closedList = new List<Cell>();
            int g = 0;

            openList.Add(start);

            while (openList.Count > 0)
            {
                var lowestF = openList.Min(l => l.F);
                curr = openList.First(l => l.F == lowestF);

                curr.setCellType(Cell.CellType.Searched);
                closedList.Add(curr);
                openList.Remove(curr);
                //curr.setCellType(Cell.CellType.Searched);

                if (closedList.FirstOrDefault(l => l.X == target.X && l.Y == target.Y) != null)
                        break;

                var adjacentSquares = grid.getWalkableAdjacentSquares(curr.X, curr.Y);
                g = curr.G + 1;

                foreach(var adjacentSquare in adjacentSquares)
                {
                    if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) != null)
                        continue;

                    if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) == null)
                    {
                        adjacentSquare.G = g;
                        adjacentSquare.H = adjacentSquare.compH(adjacentSquare.X, adjacentSquare.Y, target.X, target.Y);
                        adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                        adjacentSquare.parent = curr;
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        if (g + adjacentSquare.H < adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                            adjacentSquare.parent = curr;
                        }
                    }
                }
            }
            target = curr;
            while (curr != null)
            {
                curr.setCellType(Cell.CellType.Solved);
                curr = curr.parent;
            }
        }
    }
}
