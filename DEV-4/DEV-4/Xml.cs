using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    class Xml
    {
        private List<string> XmlAsStrings { get; set; }

        public Xml(string xmlString)
        {
            XmlParser parser = new XmlParser(xmlString);
            XmlAsStrings = parser.Parse();
        }

        public void Output()
        {
            foreach (string str in XmlAsStrings)
            {
                Console.WriteLine(str);
            }
        }

        public void Sort()
        {
            XmlAsStrings.Sort();
        }
    }
}
