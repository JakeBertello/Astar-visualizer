using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace astar
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class GridWindow : Window
    {

        private Rectangle selectedCell = new Rectangle();
        

        public GridWindow()
        {
            InitializeComponent();
            canvas.Children.Add(selectedCell);
            Grid grid = new Grid(55, 55, canvas);
            grid.DrawGrid();
            Line vGridLine = new Line()
            {
                X1 = 660,
                Y1 = 0,
                X2 = 660,
                Y2 = 660,
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };
            Line hGridLine = new Line()
            {
                X1 = 0,
                Y1 = 660,
                X2 = 660,
                Y2 = 660,
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };
            canvas.Children.Add(vGridLine);
            canvas.Children.Add(hGridLine);

            Line v2GridLine = new Line()
            {
                X1 = 0,
                Y1 = 0,
                X2 = 0,
                Y2 = 660,
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };
            Line h2GridLine = new Line()
            {
                X1 = 0,
                Y1 = 660,
                X2 = 660,
                Y2 = 660,
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };
            canvas.Children.Add(v2GridLine);
            canvas.Children.Add(h2GridLine);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void canvas_MouseEnter(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(canvas);
            if (p.X < 660 && p.Y < 660)
            {
                selectedCell.Height = 12;
                selectedCell.Width = 12;
                selectedCell.Stroke = Brushes.Yellow;
                selectedCell.Fill = Brushes.Yellow;
                Canvas.SetLeft(selectedCell, p.X - p.X % 12);
                Canvas.SetTop(selectedCell, p.Y - p.Y % 12);
            }
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Point p = e.GetPosition(canvas);
            //Rectangle wall = new Rectangle()
            //{
            //    Height = 12,
            //    Width = 12,
            //    Stroke = Brushes.Black,
            //    Fill = Brushes.Black
            //};
            //canvas.Children.Add(wall);
            //Canvas.SetLeft(wall, p.X - p.X % 12);
            //Canvas.SetTop(wall, p.Y - p.Y % 12);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(canvas);
            if (e.GetPosition(canvas).X < canvas.Width && e.GetPosition(canvas).Y < canvas.Height)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Rectangle wall = new Rectangle()
                    {
                        Height = 10,
                        Width = 10,
                        Stroke = Brushes.Blue,
                        Fill = Brushes.Blue
                    };
                    canvas.Children.Add(wall);
                    Canvas.SetLeft(wall, p.X - (p.X % 12) + 2);
                    Canvas.SetTop(wall, p.Y - (p.Y % 12) + 2);
                }
            }
            
        }

        private void canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            //canvas.Children.Remove(selectedCell);
        }
    }
}
