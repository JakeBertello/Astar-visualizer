﻿using System;
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
    }
}
