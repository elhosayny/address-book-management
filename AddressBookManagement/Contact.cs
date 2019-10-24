using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookManagement
{
    public class Contact : IComparable<Contact>
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public int CompareTo(Contact contact)
        {
            if (this.BirthDate > contact.BirthDate) return -1;
            if (this.BirthDate < contact.BirthDate) return 0;
            return 1;
        }
    }
}
