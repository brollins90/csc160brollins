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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ContactList _ContactList;
        private String SaveFileName;

        public ContactList ContactList
        {
            get { return _ContactList; }
            set { _ContactList = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            ContactList = new ContactList();
            //CreateLoadCommand();
            //CreateSaveCommand();

            ContactList.Add(new Contact()
            {
                FirstName = "First",
                LastName = "Last",
                PhoneNumbers = new ObservableCollection<PhoneNumber> {
                    new PhoneNumber("801-112-2234", ContactAttributeType.Home)
                },
                EmailAddresses = new ObservableCollection<EmailAddress> {
                    new EmailAddress("blake@blakerollins.com", ContactAttributeType.Work)
                }
            });

            ContactList.Add(new Contact()
            {
                FirstName = "Second",
                LastName = "other",
                PhoneNumbers = new ObservableCollection<PhoneNumber> {
                    new PhoneNumber("801-555-2234", ContactAttributeType.Home)
                },
                EmailAddresses = new ObservableCollection<EmailAddress> {
                    new EmailAddress("blake@otherone.com", ContactAttributeType.Work)
                }
            });

            this.DataContext = this;
        }

        private void AddPhoneButton_Click(object sender, RoutedEventArgs e)
        {
            Contact c = (Contact)ContactListBox.SelectedItem;
            c.PhoneNumbers.Add(new PhoneNumber());
        }

        private void AddEmailButton_Click(object sender, RoutedEventArgs e)
        {
            Contact c = (Contact)ContactListBox.SelectedItem;
            c.EmailAddresses.Add(new EmailAddress());
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            ContactList.Add(new Contact());
        }

        private void RemoveContactButton_Click(object sender, RoutedEventArgs e)
        {

        }




        //public ICommand SaveCommand
        //{
        //    get;
        //    internal set;
        //}

        //private bool CanExecuteSaveCommand()
        //{
        //    return (ContactList.Count != 0 && !string.IsNullOrEmpty(SaveFileName));
        //}

        //private void CreateSaveCommand()
        //{
        //    SaveCommand = new RelayCommand(SaveExecute, CanExecuteSaveCommand);
        //}

        //public void SaveExecute()
        //{
        //    ContactList.Save(SaveFileName);
        //}




        //public ICommand LoadCommand
        //{
        //    get;
        //    internal set;
        //}


        //private void CreateLoadCommand()
        //{
        //    LoadCommand = new RelayCommand(LoadExecute, true);
        //}

        //public void LoadExecute()
        //{
        //    OpenFileDialog fileSelector = new OpenFileDialog();
        //    fileSelector.Filter = "Game of Life files|*.save";
        //    fileSelector.FilterIndex = 0;

        //    bool? clickedOK = fileSelector.ShowDialog();
        //    if (clickedOK == true)
        //    {
        //        SaveFileName = fileSelector.FileName;
        //        ContactList.Load(SaveFileName);
        //    }
            
        //}
    }
}
