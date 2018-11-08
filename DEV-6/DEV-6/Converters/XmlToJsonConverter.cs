using System.Collections.Generic;
using DEV_6.Json;
using DEV_6.Xml;

namespace DEV_6.Converters
{
    class XmlToJsonConverter
    {
        public Json.Json Json { get; private set; }
        private Xml.Xml Xml { get; set; }

        public XmlToJsonConverter(Xml.Xml xml)
        {
            Xml = xml;
            Json = Convert();
        }

        private Json.Json Convert()
        {
            Json = new Json.Json
            {
                Root = XmlElementToJsonElement(Xml.Root)
            };

            return Json;
        }

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
    }
}
