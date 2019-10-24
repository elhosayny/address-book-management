using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.Linq;

namespace AddressBookManagement.Test
{
    public class AddressBookCalculatorTest
    {
        private IAddressBookLoader _addressBookLoader;
        private AddressBookCalculator _addressBookCalculator;
        public AddressBookCalculatorTest()
        {
            var mock = new Mock<IAddressBookLoader>();
            mock.Setup(addressBookLoader => addressBookLoader.GetAll()).Returns(new List<Contact>()
            {
                new Contact(){Name = "John Snow",Gender=Gender.Male,BirthDate=DateTime.Parse("16/03/77")},
                new Contact(){Name = "Jimmy Neutron",Gender=Gender.Male,BirthDate=DateTime.Parse("15/01/85")},
                new Contact(){Name = "Dana Lane",Gender=Gender.Female,BirthDate=DateTime.Parse("20/11/91")},
                new Contact(){Name = "Sarah Connor",Gender=Gender.Female,BirthDate=DateTime.Parse("20/09/80")},
                new Contact(){Name = "Chuck Jackson",Gender=Gender.Male,BirthDate=DateTime.Parse("14/08/74")},
            });

            _addressBookLoader = mock.Object;
            _addressBookCalculator = new AddressBookCalculator();
        }

        [Fact]
        public void GetOldest_InputAllPersons_ReturnChuckJackson()
        {
            var contacts = _addressBookLoader.GetAll();
            var expected = contacts.Last();

            var actual = _addressBookCalculator.GetOldest(contacts);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CountPerGender_InputAllPersons_ReturnThree()
        {
            var contacts = _addressBookLoader.GetAll();
            var expected = 3;

            var actual = _addressBookCalculator.CountPerGender(Gender.Male,contacts);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DaysBetween_InputBillAndPaul_ReturnDaysBetween()
        {
            var contact1 = new Contact() { Name = "John Snow", Gender = Gender.Male, BirthDate = DateTime.Parse("16/03/77") };
            var contact2 = new Contact() { Name = "Jimmy Neutron", Gender = Gender.Male, BirthDate = DateTime.Parse("15/01/85") };
            var expected = 2862;
            
            var actual = _addressBookCalculator.GetDaysBetween(contact1, contact2);

            Assert.Equal(expected, actual);
        }
    }
}
