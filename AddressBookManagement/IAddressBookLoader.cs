using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookManagement
{
    public interface IAddressBookLoader
    {
        string AddressBookFilePath { get; set; }
        IList<Contact> GetAll();
    }
}
