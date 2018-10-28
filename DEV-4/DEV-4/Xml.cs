using System;
using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// Keeps xml in strings
    /// </summary>
    class Xml
    {
        private List<string> XmlAsStrings { get; set; }

        public Xml(string xmlString)
        {
            XmlParser parser = new XmlParser(xmlString);
            XmlAsStrings = parser.Parse();
        }

        /// <summary>
        /// Writes xml to consol
        /// </summary>
        public void Output()
        {
            foreach (string str in XmlAsStrings)
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Sorts xml
        /// </summary>
        public void Sort()
        {
            XmlAsStrings.Sort();
        }
    }
}
