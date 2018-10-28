using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    class XmlParser
    {
        private int NTag { get; set; } = 0;
        private string XmlString { get; set; }
        private int Position { get; set; } = 0;
        private bool ElementFlag { get; set; } = false;
        private bool ValueFlag { get; set; } = false;
        public List<string> XmlAsStrings { get; set; }
        private List<string> ChainOfTags { get; set; }
        private StringBuilder Tag { get; set; }
        private static string SpecSimb { get; set; } = "\n\r\t <>";
        private static string SymbolsSkip { get; set; } = "\n\t\r ";

        public XmlParser(string xmlString)
        {
            XmlString = xmlString;
            XmlAsStrings = new List<string>();
            ChainOfTags = new List<string>();
            Tag = new StringBuilder();
        }

        public void Parse()
        {
            for (; Position < XmlString.Length; Position++)
            {
                if (IsElemStart())
                {
                    ElemStart();
                }
                if (IsElemEnd())
                {
                    ElemEnd();
                }
            }
        }

        private bool IsElemStart()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] != '/')
            {
                return true;
            }
            return false;
        }

        private void ElemStart()
        {
            ElementFlag = true;
            NTag++;
            Position++;

            ReadTag();
            
            Tag.Append("->");

            SkipSymbols();

            ReadValue();
            
            ChainOfTags.Add(Tag.ToString());
            Tag.Clear();
        }

        private bool IsElemEnd()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] == '/') 
            {
                return true;
            }
            return false;
        }

        private void ElemEnd()
        {
            if (ElementFlag)
            {
                StringBuilder big = new StringBuilder();
                foreach (string s in ChainOfTags)
                {
                    big.Append(s);
                }
                XmlAsStrings.Add(big.ToString());
                ElementFlag = false;
            }
            NTag--;
            ChainOfTags.RemoveAt(NTag);
        }

        private bool IsValueStart()
        {
            if (!SpecSimb.Contains(XmlString[Position + 1]))
            {
                return true;
            }
            return false;
        }

        private void ReadValue()
        {
            while (!SpecSimb.Contains(XmlString[Position + 1]))
            {
                Tag.Append(XmlString[Position + 1]);
                Position++;
            }
        }

        private void SkipSymbols()
        {
            while (SymbolsSkip.Contains(XmlString[Position + 1]))
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

        public void Sort()
        {
            XmlAsStrings.Sort();
        }
    }
}
