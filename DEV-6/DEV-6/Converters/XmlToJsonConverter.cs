using System.Collections.Generic;
using DEV_6.Json;
using DEV_6.Xml;

namespace DEV_6.Converters
{
    //// <summary>
    /// Converts Xml to Json
    /// </summary>
    class XmlToJsonConverter
    {
        private Xml.Xml Xml { get; set; }

        /// <summary>
        /// Converts Xml element jo Json element
        /// </summary>
        /// <param name="xmlElement">Xml element to convert</param>
        /// <returns>Json element</returns>
        private JsonElement XmlElementToJsonElement(XmlElement xmlElement)
        {
            JsonElement jsonElement = new JsonElement
            {
                Childrens = new List<JsonElement>(),
                Name = xmlElement.Tag.Name,
            };

            if (xmlElement.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlElement.Attributes)
                {
                    jsonElement.Childrens.Add(new JsonElement
                    {
                        Name = $"_{attribute.Name}",
                        Value = attribute.Value,
                        Childrens = null
                    });
                }
                if (xmlElement.Value != null)
                {
                    jsonElement.Childrens.Add(new JsonElement
                    {
                        Name = "__text",
                        Childrens = null,
                        Value = xmlElement.Value
                    });
                }
            }
            else
            {
                jsonElement.Value = xmlElement.Value;
            }
            if (xmlElement.Childrens != null)
            {
                foreach (XmlElement element in xmlElement.Childrens)
                {
                    jsonElement.Childrens.Add(XmlElementToJsonElement(element));
                }
            }
            return jsonElement;
        }

        public XmlToJsonConverter() { }

        /// <summary>
        /// Converts Xml to Json
        /// </summary>
        /// <param name="xml">Xml to convert</param>
        /// <returns>Json</returns>
        public Json.Json Convert(Xml.Xml xml)
        {
            Xml = xml;
            Json.Json json = new Json.Json
            {
                Root = XmlElementToJsonElement(Xml.Root)
            };
            return json;
        }
    }
}
