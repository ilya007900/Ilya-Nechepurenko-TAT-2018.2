using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_6.Xml
{
    /// <summary>
    /// This class parses xml string to xml
    /// </summary>
    class XmlParser
    {
        private int Level { get; set; }
        private int Position { get; set; }
        private string XmlString { get; set; }
        private static string SymbolsToIgnore { get; } = "\n\r\t";      

        /// <summary>
        /// Parses string into xml element
        /// </summary>
        /// <returns>Xml element</returns>
        private XmlElement GetElement()
        {
            XmlElement element = new XmlElement
            {
                Tag = GetTag()
            };

            if (HaveAttributes())
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
        private bool IsElementStarted()
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
        private bool IsElementEnded()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] == '/')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks childrens of element
        /// </summary>
        /// <returns>true if element have childrens</returns>
        private bool HaveChildrens()
        {
            while (true)
            {
                if (IsCommentStarted())
                {
                    IgnoreComment();
                }
                if (IsElementStarted())
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
        /// Parses string into childrens
        /// </summary>
        /// <returns>list of childrens</returns>
        private List<XmlElement> GetChildrens()
        {
            List<XmlElement> childrens = new List<XmlElement>();
            int tempLevel = Level;
            do
            {
                if (IsCommentStarted())
                {
                    IgnoreComment();
                }
                if (IsElementStarted())
                {
                    Level++;
                    childrens.Add(GetElement());
                }
                if (IsElementEnded())
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
            while (!IsElementEnded())
            {
                if (IsCommentStarted())
                {
                    IgnoreComment();
                }
                else if (!SymbolsToIgnore.Contains(XmlString[Position]))
                {
                    elemValue.Append(XmlString[Position]);
                }
                Position++;
            }
            return elemValue.ToString();
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
                if (!SymbolsToIgnore.Contains(XmlString[Position]))
                {
                    tagName.Append(XmlString[Position]);
                }
                Position++;
            }
            tag.Name = tagName.ToString();
            return tag;
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
        /// Checks is comment started
        /// </summary>
        /// <returns>true if comment is started</returns>
        private bool IsCommentStarted()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] == '!' &&
                XmlString[Position + 2] == '-' && XmlString[Position + 3] == '-')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks is comment ended
        /// </summary>
        /// <returns>true if comment is ended</returns>
        private bool IsCommentEnded()
        {
            if (XmlString[Position] == '>' && XmlString[Position - 1] == '-' && XmlString[Position - 2] == '-')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ignores comment
        /// </summary>
        private void IgnoreComment()
        {
            while (!IsCommentEnded())
            {
                Position++;
            }
        }

        /// <summary>
        /// Checks is declaration started 
        /// </summary>
        /// <returns>True if declaration is started</returns>
        private bool IsDeclarationStarted()
        {
            if (XmlString[Position] == '<' && XmlString[Position + 1] == '?')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks is declaration ended
        /// </summary>
        /// <returns>True if declaration is ended</returns>
        private bool IsDeclarationEnded()
        {
            if (XmlString[Position] == '?' && XmlString[Position + 1] == '>')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ignores declaration
        /// </summary>
        private void IgnoreDeclaration()
        {
            while (!IsDeclarationEnded())
            {
                Position++;
            }
        }

        public XmlParser() { }

        /// <summary>
        /// Strats parsing from the root element
        /// </summary>
        /// <param name="xmlString">xml string to convert</param>
        /// <returns>Xml</returns>
        public Xml Parse(string xmlString)
        {
            if (string.IsNullOrEmpty(xmlString))
            {
                throw new ArgumentNullException("Xml string is null or empty");
            }
            XmlString = xmlString;
            Xml xml = new Xml();
            while (Position < XmlString.Length)
            {
                if (IsDeclarationStarted())
                {
                    IgnoreDeclaration();
                }
                if (IsCommentStarted())
                {
                    IgnoreComment();
                }
                if (IsElementStarted())
                {
                    xml.Root = GetElement();
                    break;
                }
                Position++;
            }
            if (xml.Root == null)
            {
                throw new NullReferenceException("Incorrect xml file");
            }
            return xml;
        }
    }
}
