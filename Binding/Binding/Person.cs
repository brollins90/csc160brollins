using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Binding
{
    public class Person : INotifyPropertyChanged
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

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                this.FirePropertyChanged("FirstName");
            }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                this.FirePropertyChanged("LastName");
            }
        }

        private int _AgeInMonths;
        public int AgeInMonths
        {
            get { return _AgeInMonths; }
            set
            {
                _AgeInMonths = value;
                this.FirePropertyChanged("AgeInMonths");
            }
        }

        private bool _IsMale;
        public bool IsMale
        {
            get { return _IsMale; }
            set
            {
                _IsMale = value;
                this.FirePropertyChanged("IsMale");
            }
        }

        private int _HeightInInches;
        private double _WeightInPounds;
        private HairColor _HairColor;
        private EyeColor _EyeColor;

    }
}
