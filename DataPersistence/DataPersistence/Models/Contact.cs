using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Models
{
    [Serializable]
    public class Contact : INotifyPropertyChanged
    {
        [field:NonSerialized]
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
            set { _FirstName = value;
            this.FirePropertyChanged("FirstName");
            }
        }

        private ContactGroup _Group;

        public ContactGroup Group
        {
            get { return _Group; }
            set
            {
                _Group = value;
                this.FirePropertyChanged("Group");
            }
        }
        public IEnumerable<ContactGroup> ContactGroupValues
        {
            get
            {
                return Enum.GetValues(typeof(ContactGroup)).Cast<ContactGroup>();
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

        private string _EmailAddressHome;

        public string EmailAddressHome
        {
            get { return _EmailAddressHome; }
            set
            {
                _EmailAddressHome = value;
                this.FirePropertyChanged("EmailAddressHome");
            }
        }

        private string _EmailAddressWork;

        public string EmailAddressWork
        {
            get { return _EmailAddressWork; }
            set
            {
                _EmailAddressWork = value;
                this.FirePropertyChanged("EmailAddressWork");
            }
        }

        private string _PhoneNumberHome;

        public string PhoneNumberHome
        {
            get { return _PhoneNumberHome; }
            set
            {
                _PhoneNumberHome = value;
                this.FirePropertyChanged("PhoneNumberHome");
            }
        }

        private string _PhoneNumberWork;

        public string PhoneNumberWork
        {
            get { return _PhoneNumberWork; }
            set
            {
                _PhoneNumberWork = value;
                this.FirePropertyChanged("PhoneNumberWork");
            }
        }

        
        public Contact() {
            FirstName = "Name not set";
            Group = ContactGroup.None;
        }

        public Contact(Contact toCopy)
        {            
            this.FirstName = toCopy.FirstName;
            this.LastName = toCopy.LastName;
            this.EmailAddressHome = toCopy.EmailAddressHome;
            this.EmailAddressWork = toCopy.EmailAddressWork;
            this.PhoneNumberHome = toCopy.PhoneNumberHome;
            this.PhoneNumberWork = toCopy.PhoneNumberWork;
            this.Group = toCopy.Group;
        }
    }
}
