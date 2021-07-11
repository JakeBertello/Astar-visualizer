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
        
        
        public GridWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = new Grid(50, 50, canvas);
            grid.DrawGrid();
            //int number = 5;
            //int width = 12;
            //int height = 12;
            //int top = 20;
            //int left = 20;

            //for (int i = 0; i < number; i++)
            //{
            //    // Create the rectangle
            //    Rectangle rec = new Rectangle()
            //    {
            //        Width = width,
            //        Height = height,
            //        //Fill = Brushes.Green,
            //        Stroke = Brushes.Red,
            //        StrokeThickness = 2,
            //    };

            //    // Add to a canvas for example
            //    canvas.Children.Add(rec);
            //    Canvas.SetTop(rec, top + (i * 2));
            //    Canvas.SetLeft(rec, left + (i * 2));
            //}

            //Line redLine = new Line()
            //{
            //    X1 = 50,
            //    Y1 = 50,
            //    X2 = 200,
            //    Y2 = 200,
            //    Stroke = Brushes.Chocolate,
            //    StrokeThickness = 2
            //};
            //canvas.Children.Add(redLine);
        }
    }
}
