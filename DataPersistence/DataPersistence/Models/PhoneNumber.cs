using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Models
{
    public class PhoneNumber : INotifyPropertyChanged
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
        public string Number { get; set; }
        public ContactAttributeType AttributeType { get; set; }
        public IEnumerable<ContactAttributeType> AttributeTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(ContactAttributeType))
                    .Cast<ContactAttributeType>();
            }
        }


        //public PhoneNumber()
        //{

        //}
        
        public PhoneNumber(string number = "", ContactAttributeType attributeType = ContactAttributeType.Other)
        {
            Number = number;
            AttributeType = attributeType;
        }

        public PhoneNumber(PhoneNumber toCopy)
        {
            this.AttributeType = toCopy.AttributeType;
            this.Number = toCopy.Number;
        }
    }
}
