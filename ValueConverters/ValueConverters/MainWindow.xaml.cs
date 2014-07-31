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
    /// An example of a MultValueConverter
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// The ByteToHexStringConverter will convert a byte to a Hexidecimal string
    /// </summary>
    public class ByteToHexStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string byteString = (string)value;
            int retVal = 0;
            try { 
                retVal = int.Parse(byteString);
                retVal = (retVal > 255) ? 255 : retVal;
            }
            catch( Exception) {
                retVal = 0;
            }
            return retVal.ToString("X");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string hex = (string)value;
            try
            {
                int retVal = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                retVal = (retVal > 255) ? 255 : retVal;
                return retVal.ToString();
            }
            catch (Exception)
            {
                return 0.ToString();
            }
        }
    }

    /// <summary>
    /// The BytesToBrushConverter will retusn a SolidColorBrush from 4 bytes.
    /// </summary>
    public class BytesToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                byte aByte = (byte)int.Parse((string)values[0]);
                byte rByte = (byte)int.Parse((string)values[1]);
                byte gByte = (byte)int.Parse((string)values[2]);
                byte bByte = (byte)int.Parse((string)values[3]);

                return new SolidColorBrush(Color.FromArgb(aByte, rByte, gByte, bByte));
            }
            catch (Exception)
            {
                return new SolidColorBrush(Color.FromArgb(255,255,255,0));
            }
            
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
