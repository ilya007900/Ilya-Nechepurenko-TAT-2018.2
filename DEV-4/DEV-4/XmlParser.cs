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
        private List<string> Retres { get; set; }
        private List<string> Result { get; set; }
        private StringBuilder Tag { get; set; }
        private static string SpecSimb { get; set; } = "\n\r\t <>";
        private static string SymbolsSkip { get; set; } = "\n\t\r ";

        public XmlParser(string xmlString)
        {
            XmlString = xmlString;
            Retres = new List<string>();
            Result = new List<string>();
            Tag = new StringBuilder();
        }

        public List<string> Parse()
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
            return Retres;
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
            
            Result.Add(Tag.ToString());
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
                foreach (string s in Result)
                {
                    big.Append(s);
                }
                Retres.Add(big.ToString());
                ElementFlag = false;
            }
            NTag--;
            Result.RemoveAt(NTag);
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
    }
}
