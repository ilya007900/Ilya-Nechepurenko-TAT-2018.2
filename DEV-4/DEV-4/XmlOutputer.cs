using System;
using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// This class provides methods for output xml to console
    /// </summary>
    class XmlOutputer
    {
        private List<XmlElement> ChainOfElements { get; set; } = new List<XmlElement>();

        private Xml Xml { get; set; }

        /// <summary>
        /// Outputs xml element as xml file
        /// </summary>
        /// <param name="element">element for console output</param>
        private void OutputElementAsXml(XmlElement element)
        {
            Console.Write($"<{element.Tag.Name}");
            if (element.Attributes != null)
            {
                foreach (XmlAttribute attribute in element.Attributes)
                {
                    Console.Write($" {attribute.Name}=\"{attribute.Value}\"");
                }
            }
            Console.Write(">");
            if (element.Value != null)
            {
                Console.Write(element.Value);
                Console.Write($"</{element.Tag.Name}>\n");
            }
            else
            {
                Console.WriteLine();
                foreach (XmlElement el in element.Childrens)
                {
                    OutputElementAsXml(el);
                }
                Console.WriteLine($"</{element.Tag.Name}>");
            }
        }

        /// <summary>
        /// Outputs element with full path
        /// </summary>
        /// <param name="element">element for console output</param>
        private void OutputElementInChain(XmlElement element)
        {
            Console.Write(element.Tag.Name);
            if (element.Attributes != null)
            {
                foreach (XmlAttribute attribute in element.Attributes)
                {
                    Console.Write($" {attribute.Name}=\"{attribute.Value}\"");
                }
            }
            Console.Write("->");
            if (element.Value != null)
            {
                Console.Write(element.Value);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Outputs element with full path
        /// </summary>
        /// <param name="element">element for console output</param>
        private void OutputChainOfElements(XmlElement element)
        {
            ChainOfElements.Add(element);
            if (element.Childrens == null)
            {
                OutputElementInChain(element);
                return;
            }
            foreach (XmlElement elem in element.Childrens)
            {
                if (elem.Value != null)
                {
                    foreach (XmlElement el in ChainOfElements)
                    {
                        OutputElementInChain(el);
                    }
                    OutputElementInChain(elem);
                }
                else
                {
                    OutputChainOfElements(elem);
                }
            }
            ChainOfElements.Remove(element);
        }

        public XmlOutputer(Xml xml)
        {
            Xml = xml;
        }

        /// <summary>
        /// Outputs Root element as xml
        /// </summary>
        public void OutputAsXml()
        {
            OutputElementAsXml(Xml.Root);
        }

        /// <summary>
        /// Outputs Root element as chain of elements
        /// </summary>
        public void OutputAsChainOfElements()
        {
            OutputChainOfElements(Xml.Root);
        }
    }
}
