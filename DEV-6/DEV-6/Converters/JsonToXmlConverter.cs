using System.Collections.Generic;
using DEV_6.Json;
using DEV_6.Xml;

namespace DEV_6.Converters
{
    /// <summary>
    /// Converts Json to Xml
    /// </summary>
    class JsonToXmlConverter
    {
        private Json.Json Json { get; set; }

        /// <summary>
        /// Converts Json element to Xml element
        /// </summary>
        /// <param name="jsonElement">Json element to convert</param>
        /// <returns>Xml element</returns>
        private XmlElement JsonElementToXmlElement(Json.JsonElement jsonElement)
        {
            XmlElement xmlElement = new XmlElement();

            xmlElement.Tag = new XmlTag
            {
                Name = jsonElement.Name
            };
            xmlElement.Attributes = null;

            if (jsonElement.Childrens != null)
            {
                xmlElement.Childrens = new List<XmlElement>();
                foreach (JsonElement element in jsonElement.Childrens)
                {
                    xmlElement.Childrens.Add(JsonElementToXmlElement(element));
                }
                xmlElement.Value = null;
            }
            else
            {
                xmlElement.Value = jsonElement.Value;
                xmlElement.Childrens = null;
            }

            return xmlElement;
        }

        public JsonToXmlConverter() { }

        /// <summary>
        /// Converts Json to Xml
        /// </summary>
        /// <param name="json">Json to convert</param>
        /// <returns>Xml</returns>
        public Xml.Xml Convert(Json.Json json)
        {
            Json = json;
            Xml.Xml xml = new Xml.Xml
            {
                Root = JsonElementToXmlElement(Json.Root)
            };
            return xml;
        }
    }
}
