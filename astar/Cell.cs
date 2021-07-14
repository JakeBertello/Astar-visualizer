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
        private int Width { get; }
        private int Height { get; }
        private Canvas canvas;
        private Rectangle rect;
        private CellType cellType;
        public enum CellType
        {
            Path,
            Wall,
            StartPoint,
            EndPoint
        }
        
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
            rect = new Rectangle()
            {
                Height = Height,
                Width = Width,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            canvas.Children.Add(rect);
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
        }

        public Cell(int x, int y, CellType cellType)
        {
            if (cellType == CellType.StartPoint)
            {
                rect = new Rectangle()
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
                rect = new Rectangle()
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
                rect = new Rectangle()
                {
                    Height = Height,
                    Width = Width,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.Black
                };
            }
            canvas.Children.Add(rect);
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
        }
        public void isHovered(int mouseX, int mouseY)
        {
            if (cellType == CellType.Path && mouseInCell(mouseX, mouseY))
            {
                rect.Fill = Brushes.Yellow;
            }
        }

        private bool mouseInCell(int mouseX, int mouseY)
        {
            return (mouseX > X && mouseX < Y + Width && mouseY > Y && mouseY < Y + Height);
        }
    }
}
