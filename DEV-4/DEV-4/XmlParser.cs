using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    class XmlParser
    {
        public int NTag { get; set; } = 0;
        public string XmlString { get; set; }
        public int Position { get; set; } = 0;
        public bool Flag { get; set; } = false;
        public List<string> Retres { get; set; }
        public List<string> Result { get; set; }
        public StringBuilder Tag { get; set; }

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
                Tag.Clear();
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
            Flag = true;
            NTag++;
            Position++;
            while (XmlString[Position] != '>')
            {
                Tag.Append(XmlString[Position]);
                Position++;
            }
            if (!"\n\t\r <>".Contains(XmlString[Position + 1]))
            {
                Tag.Append("->");
                while (!"\n\t\r <>".Contains(XmlString[Position + 1]))
                {
                    Position++;
                    Tag.Append(XmlString[Position]);
                }
            }
            Result.Add(Tag.ToString() + "->");
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
            if (Flag)
            {
                StringBuilder big = new StringBuilder();
                foreach (string s in Result)
                {
                    big.Append(s);
                }
                Retres.Add(big.ToString());
                Flag = false;
            }
            NTag--;
            Result.RemoveAt(NTag);
        }
    }
}
