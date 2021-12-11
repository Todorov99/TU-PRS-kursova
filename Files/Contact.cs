using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Files
{
    public class Contact : IReader<Contact>
    {
        public string name;
        public string ID;
        public string phoneNumber;

        public Contact()
        {
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetID()
        {
            return this.ID;
        }

        public string GetPhoneNumber()
        {
            return this.phoneNumber;
        }

        public void SetName(string contactName)
        {
            this.name = contactName;
        }

        public void SetID(string id)
        {
            this.ID = id;
        }

        public void SetPhoneNumber(string number)
        {
            this.phoneNumber = number;
        }

        private bool IsSet()
        {         
            if (!string.IsNullOrEmpty(this.name) && !string.IsNullOrEmpty(this.ID) && !string.IsNullOrEmpty(this.phoneNumber))
            {
                return true;
            }

            return false;
        }

        private static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        private static List<string> SplitFileContent(string file)
        {
            IEnumerable<string> fileContent = System.IO.File.ReadLines(file);
            List<string> splitedFileContent = new List<string>();

            foreach (string line in fileContent)
            {
                string[] trimed = line.Trim().Split('\t');
               
                foreach (string t in trimed)
                {
                    string[] s = t.Trim().Split('\t');

                    foreach (string st in s)
                    {
                        splitedFileContent.Add(st.Trim());
                    }
                }
            }

            return splitedFileContent;
        }

        public List<Contact> LoadContent(string file)
        {
            List<Contact> contacts = new List<Contact>();
            Contact contact = new Contact();

            List<string> splited = Contact.SplitFileContent(file);

            foreach (string info in splited)
            {

                if (Regex.IsMatch(info, "[0-9]{6}"))
                {
                    contact.SetID(info);
                }

                if (info.Contains("+395"))
                {
                    contact.SetPhoneNumber(info);
                }

                if (Contact.IsAllLetters(info))
                {
                    contact.SetName(info);
                }


                if (contact.IsSet())
                {
                    contacts.Add(contact);
                    contact = new Contact(); 
                }
            }

            return contacts;
        }

        public override string ToString()
        {
            return String.Format("{0}: \n{1}: \n {2}: ", this.ID, this.name, this.phoneNumber);
        }
    }

}
