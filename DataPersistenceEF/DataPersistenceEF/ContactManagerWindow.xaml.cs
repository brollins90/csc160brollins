//using DataPersistence.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            // Run the Refresh to Update the ContactCollection for the first run
            SaveAndRefresh();
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
            ContactsContainer.SaveChanges();
            ContactCollection.Clear();
            IEnumerable<ContactEF> _ContactsEF = ContactsContainer.ContactEFs.ToList();
            foreach (ContactEF c in _ContactsEF)
            {
                ContactCollection.Add(c);
            }
            ContactListBox.SelectedIndex = ContactCollection.Count;
        }
    }
}
