using DataPersistence.Models;
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

        public ContactList ContactList
        {
            get { return _ContactList; }
            set { _ContactList = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            ContactList = new ContactList();

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
    }
}
