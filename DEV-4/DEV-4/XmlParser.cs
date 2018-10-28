using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    class XmlParser
    {
        private int TagNumber { get; set; } = 0;
        private string XmlString { get; set; }
        private int Position { get; set; } = 0;
        private bool ElementFlag { get; set; } = false;
        private List<string> XmlAsStrings { get; set; }
        private List<string> ListOfTags { get; set; }
        private StringBuilder Tag { get; set; }
        private static string SpecialSimbols { get; set; } = "\n\r\t <>";
        private static string SymbolsToSkip { get; set; } = "\n\t\r ";

        public XmlParser(string xmlString)
        {
            XmlString = xmlString;
            XmlAsStrings = new List<string>();
            ListOfTags = new List<string>();
            Tag = new StringBuilder();
        }

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

        private bool IsElementStart()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] != '/')
            {
                return true;
            }
            return false;
        }

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

        private bool IsElementEnd()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] == '/')
            {
                return true;
            }
            return false;
        }

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

        private bool IsValueStart()
        {
            if (!SpecialSimbols.Contains(XmlString[Position + 1]))
            {
                return true;
            }
            return false;
        }

        private void ReadValue()
        {
            while (!SpecialSimbols.Contains(XmlString[Position + 1]))
            {
                Tag.Append(XmlString[Position + 1]);
                Position++;
            }
        }

        private void SkipSymbols()
        {
            while (SymbolsToSkip.Contains(XmlString[Position + 1]))
            {
                Position++;
            }
        }

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
