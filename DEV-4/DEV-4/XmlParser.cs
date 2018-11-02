using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    /// <summary>
    /// This class parses xml string to xml
    /// </summary>
    class XmlParser
    {
        private int Level { get; set; }
        private int Position { get; set; }
        private string XmlString { get; set; }
        private static string SymbolsToSkip { get; } = "\n\r\t";

        /// <summary>
        /// Strats parsing from the root element
        /// </summary>
        /// <returns>xml</returns>
        private Xml Parse()
        {
            Xml = new Xml();
            while (Position < XmlString.Length)
            {
                if (IsElementBeginning())
                {
                    Xml.Root = GetElement();
                    break;
                }
                Position++;
            }
            return Xml;
        }

        /// <summary>
        /// Parses string into element
        /// </summary>
        /// <returns>Element</returns>
        private XmlElement GetElement()
        {
            XmlElement element = new XmlElement();

            element.Tag = GetTag();

            if (XmlString[Position] == ' ')
            {
                element.Attributes = GetAttributes();
            }
            else
            {
                element.Attributes = null;
            }

            if (HaveChildrens())
            {
                element.Childrens = GetChildrens();
            }
            else
            {
                element.Value = GetElementValue();
            }
            return element;
        }

        /// <summary>
        /// Checks the beginning of the element
        /// </summary>
        /// <returns>true if element is beginning</returns>
        private bool IsElementBeginning()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] != '/')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks the ending of the element
        /// </summary>
        /// <returns>true if element is ending</returns>
        private bool IsElementEnding()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] == '/')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Parses string into tag
        /// </summary>
        /// <returns>Tag</returns>
        private XmlTag GetTag()
        {
            XmlTag tag = new XmlTag();

            StringBuilder tagName = new StringBuilder();
            Position++;
            while (!"> ".Contains(XmlString[Position]))
            {
                if (!SymbolsToSkip.Contains(XmlString[Position]))
                {
                    tagName.Append(XmlString[Position]);
                }
                Position++;
            }
            tag.Name = tagName.ToString();
            return tag;
        }

        /// <summary>
        /// Parses string into attributes
        /// </summary>
        /// <returns>List of attributes</returns>
        private List<XmlAttribute> GetAttributes()
        {
            List<XmlAttribute> attributes = new List<XmlAttribute>();

            while (XmlString[Position] != '>')
            {
                attributes.Add(new XmlAttribute
                {
                    Name = GetAttributeName(),
                    Value = GetAttributeValue()
                });
                Position++;
            }

            return attributes;
        }

        /// <summary>
        /// Parses string into attribute name
        /// </summary>
        /// <returns>attribute name</returns>
        private string GetAttributeName()
        {
            StringBuilder name = new StringBuilder();
            Position++;
            while (XmlString[Position] != '=')
            {
                name.Append(XmlString[Position]);
                Position++;
            }

            return name.ToString();
        }

        /// <summary>
        /// Parses string into attribute value
        /// </summary>
        /// <returns>attribute value</returns>
        private string GetAttributeValue()
        {
            while (XmlString[Position] != '"')
            {
                Position++;
            }
            Position++;
            StringBuilder value = new StringBuilder();
            while (XmlString[Position] != '"')
            {
                value.Append(XmlString[Position]);
                Position++;
            }
            return value.ToString();
        }

        /// <summary>
        /// Parses string into childrens
        /// </summary>
        /// <returns>list of childrens</returns>
        private List<XmlElement> GetChildrens()
        {
            List<XmlElement> childrens = new List<XmlElement>();
            int tempLevel = Level;
            do
            {
                if (IsElementBeginning())
                {
                    Level++;
                    childrens.Add(GetElement());
                }
                if (IsElementEnding())
                {
                    Level--;
                }
                Position++;
            }
            while (tempLevel == Level);
            return childrens;
        }

        /// <summary>
        /// Parses string into element value
        /// </summary>
        /// <returns>element value</returns>
        private string GetElementValue()
        {
            StringBuilder elemValue = new StringBuilder();
            while (XmlString[Position] != '<')
            {
                if (!SymbolsToSkip.Contains(XmlString[Position]))
                {
                    elemValue.Append(XmlString[Position]);
                }
                Position++;
            }
            return elemValue.ToString();
        }

        /// <summary>
        /// Checks childrens of element
        /// </summary>
        /// <returns>true if element have childrens</returns>
        private bool HaveChildrens()
        {
            while (true)
            {
                if (XmlString[Position] == '<')
                {
                    return true;
                }
                else if (char.IsLetterOrDigit(XmlString[Position]))
                {
                    return false;
                }
                Position++;
            }
        }

        /// <summary>
        /// Checks attributes of element
        /// </summary>
        /// <returns>true if element have attributes</returns>
        private bool HaveAttributes()
        {
            while (XmlString[Position] != '>')
            {
                if (XmlString[Position] == ' ')
                {
                    return true;
                }
                Position++;
            }
            return false;
        }

        public Xml Xml { get; private set; }

        public XmlParser(string path)
        {
            XmlFileReader xmlFileReader = new XmlFileReader();
            XmlString = xmlFileReader.ReadXmlFile(path);
            Xml = Parse();
        }

    }
}
