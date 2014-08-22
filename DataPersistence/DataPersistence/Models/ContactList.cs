using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Models
{
    public class ContactList : IEnumerable<Contact>
    {
        private List<Contact> _Contacts;

        public List<Contact> Contacts
        {
            get { return _Contacts; }
            set { _Contacts = value; }
        }

        private string _FilePath;

        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }

        public ContactList()
        {
            Contacts = new List<Contact>();
        }

        public void Add(Contact c)
        {
            this.Contacts.Add(c);
            SaveFile();
        }

        private void SaveFile()
        {
            // If the filepath is NOT null
            if (!String.IsNullOrEmpty(FilePath))
            {
                // TODO
            }
        }

        public Contact Get(int index)
        {
            return new Contact(Contacts[index]);
        }

        public int Size()
        {
            return Contacts.Count;
        }


        public IEnumerator<Contact> GetEnumerator()
        {
            foreach (Contact c in Contacts)
            {
                if (c == null)
                {
                    break;
                }
                yield return c;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
