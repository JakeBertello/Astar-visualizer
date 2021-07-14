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
        Canvas canvas;
        private int height { get; set; }
        private int width { get; set; }
        private bool showSteps { get; set; }

        public Grid(int height, int width, Canvas canvas)
        {
            this.height = height;
            this.width = width;
            this.canvas = canvas;
        }
        public void DrawGrid()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Rectangle rect = new Rectangle()
                    {
                        Height = 14,
                        Width = 14,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2
                    };
                    canvas.Children.Add(rect);
                    Canvas.SetLeft(rect, i * 12);
                    Canvas.SetTop(rect, j * 12);
                }
            }
            //for (int i = 0; i < width; i++)
            //{
            //    Line vGridLine = new Line()
            //    {
            //        X1 = 12 * i,
            //        Y1 = 0,
            //        X2 = 12 * i,
            //        Y2 = 12 * height,
            //        Stroke = Brushes.Black,
            //        StrokeThickness = 2
            //    };
            //    canvas.Children.Add(vGridLine);
            //}
            

            //for (int i = 0; i < width; i++)
            //{
            //    Line hGridLine = new Line()
            //    {
            //        X1 = 0,
            //        Y1 = 12 * i,
            //        X2 = 12 * width,
            //        Y2 = 12 * i,
            //        Stroke = Brushes.Black,
            //        StrokeThickness = 2
            //    };
            //    canvas.Children.Add(hGridLine);
            //}
            //Line vGridLineBorder = new Line()
            //{
            //    X1 = 12 * width,
            //    Y1 = 0,
            //    X2 = 12 * width,
            //    Y2 = 12 * height,
            //    Stroke = Brushes.Black,
            //    StrokeThickness = 2
            //};
            //canvas.Children.Add(vGridLineBorder);

            //Line hGridLineBorder = new Line()
            //{
            //    X1 = 0,
            //    Y1 = 12 * height,
            //    X2 = 12 * width,
            //    Y2 = 12 * height,
            //    Stroke = Brushes.Black,
            //    StrokeThickness = 2
            //};
            //canvas.Children.Add(hGridLineBorder);
        }

        public void mouseHover()
        {
            Rectangle rect = new Rectangle()
            {
                Height = 40,
                Width = 40,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = Brushes.Blue
            };
            canvas.Children.Add(rect);
            Canvas.SetLeft(rect, 0);
            Canvas.SetTop(rect, 0);
        }
    }
}
