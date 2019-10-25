using System.Collections.Generic;

namespace AddressBookManagement
{
    public interface IAddressBookCalculator
    {
        int CountPerGender(Gender gender, IList<Contact> contacts);
        int GetDaysBetween(Contact contact1, Contact contact2);
        Contact GetOldest(IList<Contact> contacts);
    }
}