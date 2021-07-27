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
            Start = new int[] { 5, 5 };
            Target = new int[] { 30, 40 };
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
            setStart(Start[0], Start[1]);
            setTarget(Target[0], Target[1]);
        }

        public void setStart(int x, int y)
        {
            if (cells[y, x].getCellType() == Cell.CellType.Path)
            {
                cells[y, x].setCellType(Cell.CellType.StartPoint);
            }
        }

        public void setTarget(int x, int y)
        {
            if (cells[y, x].getCellType() == Cell.CellType.Path)
            {
                cells[y, x].setCellType(Cell.CellType.EndPoint);
            }
        }

        public void placeWall(int[] idx)
        {
            if (idx[0] >= 0 && idx[0] < 55 && idx[1] >= 0 && idx[1] < 55 && cellAt(idx[0], idx[1]).getCellType() != Cell.CellType.Path)
            {
                return;
            }
            cells[idx[0], idx[1]].setCellType(Cell.CellType.Wall);
        }

        public void clearGrid()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (cells[i, j].getCellType() != Cell.CellType.StartPoint && cells[i, j].getCellType() != Cell.CellType.EndPoint)
                    {
                        cells[i, j].setCellType(Cell.CellType.Path);
                    } 
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
            if (idx[0] >= 0 && idx[0] < 55 && idx[1] >= 0 && idx[1] < 55 && cellAt(idx[0], idx[1]).getCellType() == Cell.CellType.Wall)
                {
                cells[idx[0], idx[1]].setCellType(Cell.CellType.Path);
            }
        }

        public Cell cellAt(int y, int x)
        {
            if (x <= width && x >= 0 || y <= height && y >= 0)
            {
                return cells[y, x];
            }
            else
            {
                return cells[0, 0];
            }
        }

        public List<Cell> getWalkableAdjacentSquares(int x, int y)
        {
            List<Cell> list = new List<Cell>();
            if (y+1 <= height && cellAt(y+1, x).getCellType() == Cell.CellType.Path)
                list.Add(cellAt(y + 1, x));

            if (x+1 <= width && cellAt(y, x+1).getCellType() == Cell.CellType.Path)
                list.Add(cellAt(y, x + 1));

            if (x-1 >= 0 && cellAt(y, x-1).getCellType() == Cell.CellType.Path) 
                list.Add(cellAt(y, x - 1));

            if (y-1 >= 0 && cellAt(y-1, x).getCellType() == Cell.CellType.Path)
                list.Add(cellAt(y - 1, x));

            return list;
        }
    }
}
