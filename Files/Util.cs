using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Files
{
    public class Util
    {
        public Util()
        {
        }

        public static string ToJson<T>(List<T> contacts)
        {
            return JsonConvert.SerializeObject(contacts, Formatting.Indented);
        }

        public static List<T> FromJson<T>(string fileContent)
        {
            List<T> jsonData = JsonConvert.DeserializeObject<List<T>>(fileContent);
            return jsonData;
        }

        public static void PrintArray<T>(List<T> listOfObjects)
        {
            Console.WriteLine(Util.ToJson(listOfObjects));
        }

        public static void ConsoleInterface()
        {

            Console.WriteLine("1. Load and save coordinates from text file");
            Console.WriteLine("2. Load and save contacts from text file");
            Console.WriteLine("3. Load XML file and save all attributes starting with # and their coresponding tags in JSON file");
            Console.WriteLine("4. Load the saved coordinates from JSON file");
            Console.WriteLine("5. Load the saved contacts from JSON file");
            Console.WriteLine("6. Load the saved XML pairs from JSON file");
            Console.WriteLine("0. Exit");
        }
    }
}
