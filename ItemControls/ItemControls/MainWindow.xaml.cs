using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ItemControls.Models;

namespace ItemControls
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Character> _CharacterCollection;
        public ObservableCollection<Character> CharacterCollection { get { return _CharacterCollection; } set { _CharacterCollection = value; } }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.CharacterCollection = new ObservableCollection<Character>();
            this.CharacterCollection.Add(new Character()
            {
                CharacterClass = CharacterClass.Fighter,
                Dexterity = 1,
                Gender = Gender.Female,
                Gold = 2,
                Intelligence = 3,
                Inventory = new ObservableCollection<Item>(),
                Level = 4,
                Name = "Female Fighter",
                Strength = 5
            });
            this.CharacterCollection.Add(new Character()
            {
                CharacterClass = CharacterClass.Mage,
                Dexterity = 6,
                Gender = Gender.Female,
                Gold = 7,
                Intelligence = 8,
                Inventory = new ObservableCollection<Item>(),
                Level = 9,
                Name = "Female Mage",
                Strength = 10
            });
            this.CharacterCollection.Add(new Character()
            {
                CharacterClass = CharacterClass.Ranger,
                Dexterity = 11,
                Gender = Gender.Female,
                Gold = 12,
                Intelligence = 13,
                Inventory = new ObservableCollection<Item>(),
                Level = 14,
                Name = "Female Ranger",
                Strength = 15
            });
            this.CharacterCollection.Add(new Character()
            {
                CharacterClass = CharacterClass.Fighter,
                Dexterity = 16,
                Gender = Gender.Male,
                Gold = 17,
                Intelligence = 18,
                Inventory = new ObservableCollection<Item>(),
                Level = 19,
                Name = "Male Fighter",
                Strength = 20
            });
            this.CharacterCollection.Add(new Character()
            {
                CharacterClass = CharacterClass.Mage,
                Dexterity = 21,
                Gender = Gender.Male,
                Gold = 22,
                Intelligence = 23,
                Inventory = new ObservableCollection<Item>(),
                Level = 24,
                Name = "Male Mage",
                Strength = 25
            });
            this.CharacterCollection.Add(new Character()
            {
                CharacterClass = CharacterClass.Ranger,
                Dexterity = 26,
                Gender = Gender.Male,
                Gold = 27,
                Intelligence = 28,
                Inventory = new ObservableCollection<Item>(),
                Level = 29,
                Name = "Male Ranger",
                Strength = 30
            });


            //Image j = new Image();
            //BitmapImage src2 = new BitmapImage();
            //src2.BeginInit();
            //src2.UriSource = new Uri(@"Images\FemaleRanger.png", UriKind.Relative);
            //src2.EndInit();
            //j.Source = src2;
            //j.Stretch = Stretch.Uniform;
            //mainGame.Children.Add(j);
        }
    }
}
