using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace astar
{
    class Grid
    {
        private Cell[,] cells { get; set; }
        
        public int[] Start { get; set; }
        public int[] Target { get; set; }
        Canvas canvas;
        private int height { get; set; }
        private int width { get; set; }
        private bool showSteps { get; set; }

        public Grid(int height, int width, Canvas canvas)
        {
            cells = new Cell[height, width];
            this.height = height;
            this.width = width;
            this.canvas = canvas;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[i, j] = new Cell(i, j);
                    canvas.Children.Add(cells[i, j].Rect);
                    Canvas.SetLeft(cells[i, j].Rect, i * 12);
                    Canvas.SetTop(cells[i, j].Rect, j * 12);
                }
            }
        }

        public void setStart(int x, int y)
        {
            if (cells[y, x].getCellType() == Cell.CellType.Path)
            {
                cells[y, x].setCellType(Cell.CellType.StartPoint);
                Start[0] = y;
                Start[1] = x;
            }
        }

        public void setTarget(int x, int y)
        {
            if (cells[y, x].getCellType() == Cell.CellType.Path)
            {
                cells[y, x].setCellType(Cell.CellType.EndPoint);
                Target[0] = y;
                Target[1] = x;
            }
        }
        public void placeWall(int[] idx)
        {
            if (idx[0] >= 0 && idx[0] < 55 && idx[1] >= 0 && idx[1] < 55)
            {
                cells[idx[0], idx[1]].setCellType(Cell.CellType.Wall);
            }
        }

        public void clearGrid()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[i, j].setCellType(Cell.CellType.Path);
                }
            }
        }

        public int[] getCellIndex(int height, int width)
        {
            int[] idx = { height / 12, width / 12 };
            return idx;
        }

        public void eraseWall(int[] idx)
        {
            if (idx[0] >= 0 && idx[0] < 55 && idx[1] >= 0 && idx[1] < 55)
            {
                cells[idx[0], idx[1]].setCellType(Cell.CellType.Path);
            }
        }

        public Cell cellAt(int x, int y)
        {
            return cells[y, x];
        }

        public List<Cell> getWalkableAdjacentSquares(int x, int y)
        {
            List<Cell> list = new List<Cell>();
            list.Add(cellAt(x, y + 1));
            list.Add(cellAt(x + 1, y));
            list.Add(cellAt(x - 1, y));
            list.Add(cellAt(x, y - 1));
            return list;
        }
    }
}
