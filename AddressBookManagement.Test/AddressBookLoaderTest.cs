using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AddressBookManagement.Test
{
    public class AddressBookLoaderTest
    {
        private AddressBookLoader _addressBookLoader;

        public AddressBookLoaderTest()
        {
            var lines = new string[]
            {
                "John Snow,Male,16/03/77",
                "Jimmy Neutron,Male,15/01/85",
                "Dana Lane,Female,20/11/91",
                "Sarah Connor,Female,20/09/80",
                "Chuck Jackson,Male,14/08/74"
            };
            var mock = new Mock<IFileReader>();
            mock.Setup(fileReader => fileReader.GetAllLines(It.IsAny<string>())).Returns(lines);
            
            _addressBookLoader = new AddressBookLoader(mock.Object);
        }

        [Fact]
        public void GetAll_InputIsFilePath_ReturnContacts()
        {
            var contacts = _addressBookLoader.GetAll();

            Assert.IsType<Contact>(contacts.First());
        }

        [Fact]
        public void GetAll_InputIsFilePath_ReturnFourContacts()
        {
            var contacts = _addressBookLoader.GetAll();

            Assert.Equal(5, contacts.Count);
        }

        [Fact]
        public void GetAll_InputIsFilePath_ShouldMapPropertiesProperly()
        {
            var contacts = _addressBookLoader.GetAll();
            var firstContact = contacts.First();

            Assert.Equal("John Snow", firstContact.Name);
            Assert.Equal("Male", firstContact.Gendre);
            Assert.Equal("16/03/77", firstContact.BirthDate.ToString("dd/MM/yy"));
        }
    }
}
