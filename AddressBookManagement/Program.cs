using System;
using System.Linq;

namespace AddressBookManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world");
            var filePath = @"C:\Users\admin\Desktop\data.txt";
            var fileReader = new FileReader();
            var loader = new AddressBookLoader(fileReader) { AddressBookFilePath = filePath };
            var contacts = loader.GetAll();
            Console.WriteLine("Count is : "+contacts.Count);
            Console.WriteLine("Count is : "+contacts.First().BirthDate.ToShortDateString());
            

        }
    }
}
