using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace astar
{
    class Cell
    {
        private int X { get; set; }
        private int Y { get; set; }
        private int Width = 14;
        private int Height = 14;

        public Rectangle Rect { get; set; }

        private CellType cellType;
        public enum CellType
        {
            Path,
            Wall,
            StartPoint,
            EndPoint,
            Hovered
        }
        
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Rect = new Rectangle()
            {
                Height = Height,
                Width = Width,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            cellType = CellType.Path;
        }

        public Cell(int x, int y, CellType cellType)
        {
            if (cellType == CellType.StartPoint)
            {
                Rect = new Rectangle()
                {
                    Height = Height,
                    Width = Width,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.Green
                };
            }
            else if (cellType == CellType.EndPoint)
            {
                Rect = new Rectangle()
                {
                    Height = Height,
                    Width = Width,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.Blue
                };
            }
            else if (cellType == CellType.Wall)
            {
                Rect = new Rectangle()
                {
                    Height = Height,
                    Width = Width,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.Black
                };
            }
        }
        public CellType getCellType()
        {
            return cellType;
        }

        public void setCellType(CellType cellType)
        {
            this.cellType = cellType;
            switch(cellType)
            {
                case CellType.Path:
                    Rect.Fill = Brushes.White;
                    break;
                case CellType.Wall:
                    Rect.Fill = Brushes.Black;
                    break;
                case CellType.StartPoint:
                    Rect.Fill = Brushes.Green;
                    break;
                case CellType.EndPoint:
                    Rect.Fill = Brushes.Red;
                    break;
                case CellType.Hovered:
                    Rect.Fill = Brushes.Yellow;
                    break;
            }
        }
        public int getWidth()
        {
            return Width;
        }
        
        public void setWidth(int Width)
        {
            this.Width = Width;
        }

        public int getHeight()
        {
            return Height;
        }

        public void setHeight(int Height)
        {
            this.Height = Height;
        }
    }
}
