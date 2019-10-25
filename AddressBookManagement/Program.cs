using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AddressBookManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAddressBookLoader, AddressBookLoader>()
                .AddSingleton<IAddressBookCalculator, AddressBookCalculator>()
                .AddSingleton<IFileReader, FileReader>()
                .BuildServiceProvider();

            var addressBookLoader = serviceProvider.GetService<IAddressBookLoader>();
            var addressBookCalculator = serviceProvider.GetService<IAddressBookCalculator>();
            addressBookLoader.AddressBookFilePath = "C:\\contacts.txt";
            var contacts = addressBookLoader.GetAll();

            Console.WriteLine("Q : How many males are in the address book ?");
            Console.WriteLine($"A : {addressBookCalculator.CountPerGender(Gender.Male,contacts)}");

            Console.WriteLine("Q : Who is the oldest person in the address book ?");
            Console.WriteLine($"A : {addressBookCalculator.GetOldest(contacts).Name}");

            Console.WriteLine("Q : How many days older is John than Jimmy ?");
            Console.WriteLine($"A : {addressBookCalculator.GetDaysBetween(contacts[0], contacts[1])}");

        }
    }
}
