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

namespace ValueConverters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }



    public class ByteToHexStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string byteString = (string)value;
            int retVal = 0;
            try { 
                retVal = int.Parse(byteString);
            }
            catch( Exception) {
                
            }
            return retVal.ToString("X");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string hex = (string)value;
            try
            {
                return int.Parse(hex, System.Globalization.NumberStyles.HexNumber).ToString();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }

    public class BytesToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new SolidColorBrush(Color.FromArgb((byte)int.Parse((string)values[0]), (byte)int.Parse((string)values[1]), (byte)int.Parse((string)values[2]), (byte)int.Parse((string)values[3])));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
