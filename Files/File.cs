using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Files
{
    public class File
    {
        private string fileName;

        public File(string fileName)
        {
            this.fileName = fileName;
        }

        public File()
        {
        }

        public void SaveToJSON<T>(List<T> obj)
        {
            System.IO.File.WriteAllTextAsync(this.fileName, Util.ToJson(obj));
        }

        public List<T> ReadFromJSON<T>()
        {
            List<T> jsonData = new List<T>();
            try
            {
                StreamReader reader = new StreamReader(this.fileName);
                jsonData = Util.FromJson<T>(reader.ReadToEnd());
                
            }catch (FileNotFoundException e)
            {
                Console.WriteLine("File you entered: {0} is incorrect", this.fileName, e);
            }

            return jsonData;

        }

      
    }
}
