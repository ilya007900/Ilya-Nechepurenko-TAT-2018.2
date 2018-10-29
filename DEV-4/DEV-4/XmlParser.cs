using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    /// <summary>
    /// Parses Xml string
    /// </summary>
    class XmlParser
    {
        private int TagNumber { get; set; } = 0;
        private string XmlString { get; set; }
        private int Position { get; set; } = 0;
        private bool ElementFlag { get; set; } = false;
        private List<string> XmlAsStrings { get; set; }
        private List<string> ListOfTags { get; set; }
        private StringBuilder Tag { get; set; }
        private static string SpecialSymbols { get; set; } = "<>";
        private static string SymbolsToSkip { get; set; } = "\n\t\r ";

        public XmlParser(string xmlString)
        {
            XmlString = xmlString;
            XmlAsStrings = new List<string>();
            ListOfTags = new List<string>();
            Tag = new StringBuilder();
        }

        /// <summary>
        /// Parse string xml to strings 
        /// </summary>
        /// <returns>xml in strings</returns>
        /// <exception cref="Exception">thrown if xml file is incorrect</exception>
        public List<string> Parse()
        {
            for (; Position < XmlString.Length; Position++)
            {
                if (IsElementStart())
                {
                    ReadElement();
                }
                if (IsElementEnd())
                {
                    WriteElement();
                }
            }
            if (TagNumber != 0)
            {
                throw new Exception("Incorrect xml file");
            }
            return XmlAsStrings;
        }

        /// <summary>
        /// Checks element is begins
        /// </summary>
        /// <returns>true if element is begins</returns>
        private bool IsElementStart()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] != '/')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Reads element in string
        /// </summary>
        private void ReadElement()
        {
            ElementFlag = true;
            TagNumber++;
            Position++;

            ReadTag();

            Tag.Append("->");

            SkipSymbols();

            ReadValue();

            ListOfTags.Add(Tag.ToString());
            Tag.Clear();
        }

        /// <summary>
        /// Checks element is ending
        /// </summary>
        /// <returns>true if element is ending</returns>
        private bool IsElementEnd()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] == '/')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Writes element in strings
        /// </summary>
        private void WriteElement()
        {
            if (ElementFlag)
            {
                StringBuilder chainOfTagsAsString = new StringBuilder();
                foreach (string s in ListOfTags)
                {
                    chainOfTagsAsString.Append(s);
                }
                XmlAsStrings.Add(chainOfTagsAsString.ToString());
                ElementFlag = false;
            }
            TagNumber--;
            ListOfTags.RemoveAt(TagNumber);
        }

        /// <summary>
        /// Checks is value is begins
        /// </summary>
        /// <returns>true if value is begins</returns>
        private bool IsValueStart()
        {
            if ((!SpecialSymbols.Contains(XmlString[Position + 1])) &&
                (!SymbolsToSkip.Contains(XmlString[Position + 1])))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Reads value in string
        /// </summary>
        private void ReadValue()
        {
            while ((!SpecialSymbols.Contains(XmlString[Position + 1])) &&
                    (!SymbolsToSkip.Contains(XmlString[Position + 1])))
            {
                Tag.Append(XmlString[Position + 1]);
                Position++;
            }
        }

        /// <summary>
        /// Skips symbols to skip
        /// </summary>
        private void SkipSymbols()
        {
            while (SymbolsToSkip.Contains(XmlString[Position + 1]))
            {
                Position++;
            }
        }

        /// <summary>
        /// Reads tag in string
        /// </summary>
        private void ReadTag()
        {
            while (XmlString[Position] != '>')
            {                
                Tag.Append(XmlString[Position]);
                Position++;
            }
        }
    }
}
