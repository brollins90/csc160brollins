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
        private Random _Random;
        private string[] firstNames = {
                                          "Jessie",
                                          "Alex",
                                          "Dylan",
                                          "Tylee",
                                          "Taylor"
                                      };
        private string[] lastNames = {
                                         "Baker",
                                         "Burdin",
                                         "Cox",
                                         "Filler",
                                         "Martz",
                                         "Newkirk",
                                         "Peterson",
                                         "Rollins"
                                     };


        public void FirePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                Console.WriteLine("MainWindow.FirePropertyChanged({0})", propertyName);
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // static get random enum method.  Found at: http://stackoverflow.com/questions/3132126/how-do-i-select-a-random-value-from-an-enumeration

        public T RandomEnumValue<T>()
        {
            return Enum
                .GetValues(typeof(T))
                .Cast<T>()
                .OrderBy(x => _Random.Next())
                .FirstOrDefault();
        }

        public Person()
        {
            _Random = new Random();
            this.MakeRandomPerson();
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
        public int HeightInInches
        {
            get { return _HeightInInches; }
            set
            {
                _HeightInInches = value;
                this.FirePropertyChanged("HeightInInches");
            }
        }

        private double _WeightInPounds;
        public double WeightInPounds
        {
            get { return _WeightInPounds; }
            set
            {
                _WeightInPounds = value;
                this.FirePropertyChanged("WeightInPounds");
            }
        }

        private HairColorEnum _HairColor;
        public HairColorEnum HairColor 
        {
            get { return _HairColor; }
            set
            {
                _HairColor = value;
                this.FirePropertyChanged("HairColor");
            }
        }

        private EyeColorEnum _EyeColor;
        public EyeColorEnum EyeColor
        {
            get { return _EyeColor; }
            set
            {
                _EyeColor = value;
                this.FirePropertyChanged("EyeColor");
            }
        }

        internal void MakeRandomPerson()
        {
            this.AgeInMonths = _Random.Next(1, (120 * 12) + 1);
            this.EyeColor = RandomEnumValue<EyeColorEnum>();
            this.FirstName = firstNames[_Random.Next(0, firstNames.Length)];
            this.HairColor = RandomEnumValue<HairColorEnum>(); //= Enum.GetValues(typeof(HairColor)).Cast<HairColor>/.OrderBy(x => _Random.Next()).FirstOrDefault();
            this.HeightInInches = _Random.Next(4, 84);
            this.IsMale = (_Random.Next(0,2) == 0);
            this.LastName = lastNames[_Random.Next(0, lastNames.Length)];
            this.WeightInPounds = (double)_Random.Next(11, 2500) / 10.0;
        }


    }
}
