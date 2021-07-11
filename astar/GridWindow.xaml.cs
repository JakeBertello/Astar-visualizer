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

        private void DrawTiles(int width, int height)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Brushes.Black, 3);

            Rectangle rect = new Rectangle();
            
        }
    }
}
