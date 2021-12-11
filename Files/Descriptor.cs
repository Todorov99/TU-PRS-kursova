using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Files
{ 
    public class Descriptor : IReader<Descriptor>
    {
        public string connection;
        public string tag;
        

        public Descriptor()
        {
        }

        public Descriptor(string connection, string tag)
        {
            this.connection = connection;
            this.tag = tag;
        }

        public List<Descriptor> LoadContent(string file)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(file);

            XmlElement root = xmlDocument.DocumentElement;
            IEnumerator rootNodes = root.GetEnumerator();

            return IterateOver(rootNodes);
        }

        private List<Descriptor> IterateOver(IEnumerator elementNode)
        {
            List<Descriptor> descriptors = new List<Descriptor>();

            while (elementNode.MoveNext())
            {
                try
                {
                    XmlElement xmlElement = (XmlElement)elementNode.Current;

                    IEnumerator atr = xmlElement.Attributes.GetEnumerator();
                    while (atr.MoveNext())
                    {
                        XmlAttribute attribute = (XmlAttribute)atr.Current;
                        string attributeValue = attribute.Value;
                        if (attributeValue.StartsWith("#"))
                        {
                            string[] splitedAtr = attributeValue.Split("#");
                            string tag = splitedAtr[1];
                           
                            XmlElement attrElement = attribute.OwnerElement;
                           
                            Descriptor descriptor = new Descriptor(attrElement.Name.Normalize(), tag);
                            descriptors.Add(descriptor);
                        }
                        
                    }

                    List<Descriptor> inner = IterateOver(xmlElement.GetEnumerator());
                    descriptors.AddRange(inner);
              
                }
                catch (InvalidCastException)
                {
                    continue;
                }
               
            }

            return descriptors;
        }

        public override string ToString()
        {
            return String.Format("{0}: \n{1}: ", this.connection, this.tag);
        }
    }
}
