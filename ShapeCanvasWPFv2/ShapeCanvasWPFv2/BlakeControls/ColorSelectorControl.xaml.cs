using ShapeCanvasWPFv2.Models;
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

namespace ShapeCanvasWPFv2.BlakeControls
{
    /// <summary>
    /// Interaction logic for ColorSelectorControl.xaml
    /// </summary>
    public partial class ColorSelectorControl : UserControl
    {
        public ColorSelectorModel _Model;
        public ColorSelectorModel Model {
            get { return _Model; }
            set { _Model = value; }
        }

        public ColorSelectorControl()
        {
            InitializeComponent();
            Model = new ColorSelectorModel();
            DataContext = Model;
            //Grid TransparentLinesGrid = new Grid();
            //TransparentLinesGrid.ShowGridLines = true;
            for (int i = 0; i < 5; i++) { 
                TransparentLinesGrid.RowDefinitions.Add(new RowDefinition());
                TransparentLinesGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            
            //ColorSelectorPanel.Children.Add(TransparentLinesGrid);
            //ColorPreview.DataContext = this;
        }
    }

    public class ColorToBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color c = (Color)value;
            return new SolidColorBrush(c);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
