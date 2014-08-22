using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void FirePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                //Console.WriteLine("ColorSelectorModel.FirePropertyChanged({0})", propertyName);
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public enum ContactGroup
        {
            Family, Friends, Coworkers, None, Other
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private ContactGroup _Group;

        public ContactGroup Group
        {
            get { return _Group; }
            set { _Group = value; }
        }
        public IEnumerable<ContactGroup> ContactGroupValues
        {
            get
            {
                return Enum.GetValues(typeof(ContactGroup))
                    .Cast<ContactGroup>();
            }
        }


        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private ObservableCollection<EmailAddress> _EmailAddresses;
        public ObservableCollection<EmailAddress> EmailAddresses
        {
            get { return _EmailAddresses; }
            set { _EmailAddresses = value; }
        }

        private ObservableCollection<PhoneNumber> _PhoneNumbers;
        public ObservableCollection<PhoneNumber> PhoneNumbers
        {
            get { return _PhoneNumbers; }
            set { _PhoneNumbers = value; }
        }
        // IM
        // Title
        // Office
        // Department
        // Company
        // Addresses
        // Birthday

        
        public Contact() {
            PhoneNumbers = new ObservableCollection<PhoneNumber>();
            EmailAddresses = new ObservableCollection<EmailAddress>();
            Group = ContactGroup.None;
        }

        public Contact(Contact toCopy)
        {
            
            this.FirstName = toCopy.FirstName;
            this.LastName = toCopy.LastName;
            foreach(EmailAddress e in toCopy.EmailAddresses) {
                this.EmailAddresses.Add(new EmailAddress(e));
            }
            foreach(PhoneNumber p in toCopy.PhoneNumbers) {
                this.PhoneNumbers.Add(new PhoneNumber(p));
            }
            this.Group = toCopy.Group;
        }

    }
}
