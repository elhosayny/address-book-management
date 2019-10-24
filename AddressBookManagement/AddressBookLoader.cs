using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookManagement
{
    public class AddressBookLoader : IAddressBookLoader
    {
        private IFileReader _fileReader;

        public string AddressBookFilePath { get; set; }

        public AddressBookLoader(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IList<Contact> GetAll()
        {
            var lines = _fileReader.GetAllLines(AddressBookFilePath);
            var contacts = new List<Contact>();
            foreach (var line in lines)
            {
                var newContact = new Contact()
                {
                    Name = line.Split(',')[0],
                    Gendre = line.Split(',')[1],
                    BirthDate = DateTime.Parse(line.Split(',')[2])
                };
                contacts.Add(newContact);
            }

            return contacts;
        }
    }
}
