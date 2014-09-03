//using DataPersistence.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Validation;
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
    /// A simple contact list that stores data by using the EntityFramework
    /// 
    /// Blake Rollins
    /// </summary>
    public partial class MainWindow : Window
    {

        private int previousIndex = 0;

        // Make a list of values for the UI to use as a Combobox source
        public IEnumerable<ContactGroup> ContactGroupValues { get { return Enum.GetValues(typeof(ContactGroup)).Cast<ContactGroup>(); } }

        // The DatabaseContext to use
        public ContactModelContainer ContactsContainer { get; set; }
        // The Collection that we are storing the results in
        public ObservableCollection<ContactEF> ContactCollection { get; set; }

        public MainWindow()
        {
            // Initialize the Arrays
            InitializeComponent();
            ContactsContainer = new ContactModelContainer();
            ContactCollection = new ObservableCollection<ContactEF>();
            this.DataContext = this;
            ContactCollection.CollectionChanged += ContactsChanged;

            // Run the Refresh to Update the ContactCollection for the first run
            SaveAndRefresh();
        }

        private void ContactsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Save();
        }

        // Add a new Contact Entity
        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            ContactsContainer.ContactEFs.Add(new ContactEF());
            SaveAndRefresh();
        }

        // Remove the selected Contact from the DB
        private void RemoveContactButton_Click(object sender, RoutedEventArgs e)
        {
            ContactsContainer.ContactEFs.Remove((ContactEF)ContactListBox.SelectedItem);
            SaveAndRefresh();
        }

        // Save the Data and Refresh the UI
        private void SaveAndRefresh()
        {
            Save();
            Refresh();
        }

        private void Save()
        {
            ContactsContainer.SaveChanges();
        }

        private void Refresh()
        {
            ContactCollection.Clear();
            IEnumerable<ContactEF> _ContactsEF = ContactsContainer.ContactEFs.ToList();
            foreach (ContactEF c in _ContactsEF)
            {
                c.PropertyChanged += OnPropertyChanged;
                ContactCollection.Add(c);
            }
            ContactListBox.SelectedIndex = ContactCollection.Count - 1; // (previousIndex >= 0) ? previousIndex : (previousIndex < ContactCollection.Count) ? previousIndex : 0;
        }

        private void OnPropertyChanged(
            Object sender, PropertyChangedEventArgs e)
        {
            ContactEF c = sender as ContactEF;
            if (c != null)
            {
                c.PropertyChanged -= OnPropertyChanged;
                ContactEF o = ContactsContainer.ContactEFs.FirstOrDefault<ContactEF>(x => x.Id == c.Id);
                o.EmailAddressHome = c.EmailAddressHome;
                o.EmailAddressWork = c.EmailAddressWork;
                o.FirstName = c.FirstName;
                o.Group = c.Group;
                //o.Id = c.Id;
                o.LastName = c.LastName;
                o.PhoneNumberHome = c.PhoneNumberHome;
                o.PhoneNumberWork = c.PhoneNumberWork;
                o.PropertyChanged += OnPropertyChanged;
                Save();
                //Refresh();
            }
        }

        private void ContactListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            previousIndex = ContactListBox.SelectedIndex;
        }
    }
}
