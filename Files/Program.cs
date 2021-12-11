using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Files
{
    class Program
    {
        private const string COORDINATE_FILE_PATH = "./contentFiles/coordinates.txt";
        private const string CONTACT_FILE_PATH = "./contentFiles/contacts.txt";
        private const string XML_FILE_PATH = "./contentFiles/input.xml";

        private const string EXIT = "0";
        private const string SAVE_COORDINATES = "1";
        private const string SAVE_CONTACTS = "2";
        private const string SAVE_XML_CONNECTION = "3";
        private const string READ_COORDINATES = "4";
        private const string READ_CONTACTS = "5";
        private const string READ_XML_CONNECTION = "6";

        static void Main(string[] args)
        {

            Util.ConsoleInterface();
            
            while(true)
            {
                Console.WriteLine("Enter option from 0 to 6");
                string option = Console.ReadLine();

                switch (option)
                {
                    case SAVE_COORDINATES:
                        Console.WriteLine("Enter the JSON filename where you want to save the coordinates");
                        string coordinatesFilename = Console.ReadLine();
                        Coordinate coordinate = new Coordinate();
                        List<Coordinate> coordinates = coordinate.LoadContent(COORDINATE_FILE_PATH);
                        File file = new File(coordinatesFilename);
                        file.SaveToJSON(coordinates);
                        continue;
                    case SAVE_CONTACTS:
                        Console.WriteLine("Enter the JSON filename where you want to save the contacts");
                        string contactsFilename = Console.ReadLine();
                        Contact contact = new Contact();
                        List<Contact> contacts = contact.LoadContent(CONTACT_FILE_PATH);
                        file = new File(contactsFilename);
                        file.SaveToJSON(contacts);
                        continue;
                    case SAVE_XML_CONNECTION:
                        Console.WriteLine("Enter the JSON filename where you want to save the XML connections");
                        string xmlConnections = Console.ReadLine();
                        Descriptor descriptor = new Descriptor();
                        List<Descriptor> descriptors = descriptor.LoadContent(XML_FILE_PATH);
                        file = new File(xmlConnections);
                        file.SaveToJSON(descriptors);
                        continue;
                    case READ_COORDINATES:
                        Console.WriteLine("Enter the JSON filename from where you want to read the coordinates");
                        string jsonFileName = Console.ReadLine();
                        file = new File(jsonFileName);
                        List<Coordinate> c = file.ReadFromJSON<Coordinate>();
                        Util.PrintArray(c);
                        continue;
                    case READ_CONTACTS:
                        Console.WriteLine("Enter the JSON filename from where you want to read the contacts");
                        string contactsJsonFileName = Console.ReadLine();
                        file = new File(contactsJsonFileName);
                        List<Contact> con = file.ReadFromJSON<Contact>();
                        Util.PrintArray(con);
                        continue;
                    case READ_XML_CONNECTION:
                        Console.WriteLine("Enter the JSON filename from where you want to read the XML connections");
                        string xmlConnectionsJsonFileName = Console.ReadLine();
                        file = new File(xmlConnectionsJsonFileName);
                        List<Descriptor> des = file.ReadFromJSON<Descriptor>();
                        Util.PrintArray(des);
                        continue;
                    case EXIT:
                        System.Environment.Exit(0);
                        continue;
                    default:
                        break;
                }
            }

        }
    }
}
