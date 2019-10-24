using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookManagement
{
    public interface IFileReader
    {
        string[] GetAllLines(string filePath);
    }
}
