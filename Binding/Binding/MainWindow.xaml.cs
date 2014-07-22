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
using System.ComponentModel;

namespace Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void FirePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                Console.WriteLine("MainWindow.FirePropertyChanged({0})", propertyName);
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Person = new Person();
        }

        private Person _Person;
        public Person Person
        {
            get { return _Person; }
            set
            {
                _Person = value;
                this.FirePropertyChanged("Person");
            }
        }

        private void RandomPerson_Click(object sender, RoutedEventArgs e)
        {
            this.Person.MakeRandomPerson();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //this.Close();
        }
    }

    public class AgeToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int numMonths = (int)value;
            if (numMonths < 24)
            {
                return "" + numMonths + " Months";
            }
            return "" + (numMonths / 12) + " Years";
            ///return "" + (numMonths / 12) + " Years (" + numMonths + ")";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToMaleConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? "Male" : "Female";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class HeightToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int height = (int)value;
            int feet = height / 12;
            int inches = height % 12;
            string retVal = "" + feet;
            retVal += (feet == 1) ? " foot" : " feet";
            if (inches > 0)
                retVal += ", " + inches + " inch";
            if (inches > 1)
                retVal += "es";
            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
