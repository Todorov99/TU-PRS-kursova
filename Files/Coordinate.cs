using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Files
{
    public class Coordinate : IReader<Coordinate>
    {
        public float lat;
        public float lang;

        public Coordinate ()
        {

        }

        public Coordinate(float lat, float lang)
        {
            this.lat = lat;
            this.lang = lang;
        }

        public List<Coordinate> LoadContent(string file)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines)
            { 
                string[] currentLine = line.Split(';');
              
                foreach (string l in currentLine)
                {
                    string[] elementsOftheLine = l.Split(',');
                    coordinates.Add(new Coordinate(float.Parse(elementsOftheLine[0]), float.Parse(elementsOftheLine[1])));
                }

            }

            return coordinates;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.lat, this.lang);
        }
    }
}
