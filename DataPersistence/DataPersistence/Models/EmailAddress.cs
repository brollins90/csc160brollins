using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Models
{
    public class EmailAddress : INotifyPropertyChanged
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

        public string Address { get; set; }
        public ContactAttributeType AttributeType { get; set; }
        public IEnumerable<ContactAttributeType> AttributeTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(ContactAttributeType))
                    .Cast<ContactAttributeType>();
            }
        }

        public EmailAddress(string address = "", ContactAttributeType attributeType = ContactAttributeType.Other)
        {
            Address = address;
            AttributeType = attributeType;
        }
        public EmailAddress(EmailAddress toCopy)
        {
            this.Address = toCopy.Address;
            this.AttributeType = toCopy.AttributeType;
        }
    }
}
