using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookManagement
{
    public interface IAddressBookLoader
    {
        IList<Contact> GetAll();
    }
}
