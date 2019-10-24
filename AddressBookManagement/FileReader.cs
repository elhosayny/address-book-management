using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookManagement
{
    public class FileReader : IFileReader
    {
        public string[] GetAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
