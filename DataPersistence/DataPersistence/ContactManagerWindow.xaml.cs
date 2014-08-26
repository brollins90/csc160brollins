using DataPersistence.Models;
using Microsoft.Win32;
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

namespace DataPersistence
{
    /// <summary>
    /// A simple contact list that serializes data to a file
    /// 
    /// Blake Rollins
    /// </summary>
    public partial class MainWindow : Window
    {
        private String SaveFileName;

        private ObservableCollection<Contact> _ContactCollection;

        public ObservableCollection<Contact> ContactCollection
        {
            get { return _ContactCollection; }
            set { _ContactCollection = value; }
        }


        public MainWindow()
        {
            InitializeComponent();
            ContactCollection = new ObservableCollection<Contact>();
            this.DataContext = this;
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            ContactCollection.Add(new Contact());
            ContactListBox.SelectedIndex = ContactCollection.Count - 1;
        }

        private void RemoveContactButton_Click(object sender, RoutedEventArgs e)
        {
            ContactCollection.Remove((Contact)ContactListBox.SelectedItem);
            ContactListBox.SelectedIndex = 0;
        }


        private void SaveCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Serializer.SerializeObject<ObservableCollection<Contact>>(SaveFileName, ContactCollection);
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (ContactCollection.Count != 0 && !string.IsNullOrEmpty(SaveFileName));
        }


        private void SaveAsCommand(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog fileSelector = new SaveFileDialog();
            fileSelector.Filter = "Contacts | *.contacts";
            fileSelector.FilterIndex = 0;

            bool? ok = fileSelector.ShowDialog();
            if (ok == true)
            {
                SaveFileName = fileSelector.FileName;
                Serializer.SerializeObject<ObservableCollection<Contact>>(SaveFileName, ContactCollection);
            }
        }

        private void SaveAsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        private void OpenCommand(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog fileSelector = new OpenFileDialog();
            fileSelector.Filter = "Contacts | *.contacts";
            fileSelector.FilterIndex = 0;

            bool? ok = fileSelector.ShowDialog();
            if (ok == true)
            {
                SaveFileName = fileSelector.FileName;
                ContactCollection.Clear();
                ObservableCollection<Contact> col = Serializer.DeserializeObject<ObservableCollection<Contact>>(SaveFileName);
                foreach (Contact c in col) {
                    ContactCollection.Add(c);
                }
            }
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
