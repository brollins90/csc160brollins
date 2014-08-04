using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ItemControls.Models
{
    public class Character
    {
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }

        private int _Level;
        public int Level { get { return _Level; } set { _Level = value; } }

        private CharacterClass _CharacterClass;
        public CharacterClass CharacterClass { get { return _CharacterClass; } set { _CharacterClass = value; } }

        private Gender _Gender;
        public Gender Gender { get { return _Gender; } set { _Gender = value; } }

        private int _Strength;
        public int Strength { get { return _Strength; } set { _Strength = value; } }

        private int _Intelligence;
        public int Intelligence { get { return _Intelligence; } set { _Intelligence = value; } }

        private int _Dexterity;
        public int Dexterity { get { return _Dexterity; } set { _Dexterity = value; } }

        private int _Gold;
        public int Gold { get { return _Gold; } set { _Gold = value; } }

        private ObservableCollection<Item> _Inventory;
        public ObservableCollection<Item> Inventory { get { return _Inventory; } set { _Inventory = value; } }

        public override string ToString()
        {
            return Name;
        }

    }

    public class CharacterToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Character c = (Character)value;
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(@"Images\FemaleRanger.png", UriKind.Relative);

            if (c.CharacterClass == CharacterClass.Fighter && c.Gender == Gender.Female)
                src.UriSource = new Uri(@"Images\FemaleFighter.png", UriKind.Relative);
            if (c.CharacterClass == CharacterClass.Fighter && c.Gender == Gender.Male)
                src.UriSource = new Uri(@"Images\MaleFighter.png", UriKind.Relative);
            if (c.CharacterClass == CharacterClass.Mage && c.Gender == Gender.Female)
                src.UriSource = new Uri(@"Images\FemaleMage.png", UriKind.Relative);
            if (c.CharacterClass == CharacterClass.Mage && c.Gender == Gender.Male)
                src.UriSource = new Uri(@"Images\MaleMage.png", UriKind.Relative);
            if (c.CharacterClass == CharacterClass.Ranger && c.Gender == Gender.Female)
                src.UriSource = new Uri(@"Images\FemaleRanger.png", UriKind.Relative);
            if (c.CharacterClass == CharacterClass.Ranger && c.Gender == Gender.Male)
                src.UriSource = new Uri(@"Images\MaleRanger.png", UriKind.Relative);

            src.EndInit();
            return src;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
