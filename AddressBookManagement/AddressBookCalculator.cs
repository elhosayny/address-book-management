using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookManagement
{
    public class AddressBookCalculator : IAddressBookCalculator
    {

        public int CountPerGender(Gender gender, IList<Contact> contacts)
        {
            return contacts.Where(contact => contact.Gender == gender).Count();
        }

        public Contact GetOldest(IList<Contact> contacts)
        {
            return contacts.Max();
        }

        public int GetDaysBetween(Contact contact1, Contact contact2)
        {
            var days = (int)(contact1.BirthDate - contact2.BirthDate).TotalDays;
            return Math.Abs(days);
        }
    }
}
