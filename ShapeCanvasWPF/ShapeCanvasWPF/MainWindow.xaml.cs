using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShapeCanvasWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint = new Point();
        Color currentColor = Color.FromArgb(255, 0, 0, 0);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayCanvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void PlayCanvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                //line.Stroke = SystemColors.WindowFrameBrush;
                line.Stroke = new SolidColorBrush(currentColor);
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint = e.GetPosition(this);

                PlayCanvas.Children.Add(line);
            }
        }

        private void buttonShapeRandom_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonShapeTriangle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonShapeRectangle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonColorRed_Click(object sender, RoutedEventArgs e)
        {
            currentColor = Color.FromArgb(255, 255, 0, 0);
        }

        private void buttonColorGreen_Click(object sender, RoutedEventArgs e)
        {
            currentColor = Color.FromArgb(255, 0, 255, 0);
        }

        private void buttonColorBlue_Click(object sender, RoutedEventArgs e)
        {
            currentColor = Color.FromArgb(255, 0, 0, 255);
        }
    }
}
