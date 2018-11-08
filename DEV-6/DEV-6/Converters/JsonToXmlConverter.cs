using System;
using System.Collections.Generic;
using System.Text;
using DEV_6.Json;

namespace DEV_6.Converters
{
    class JsonToXmlConverter
    {
        private Json.Json Json { get; set; }
        public Xml Xml { get; private set; }

        public JsonToXmlConverter(Json.Json json)
        {
            Json = json;
            Xml = Convert();
        }

        private Xml Convert()
        {
            Xml xml = new Xml
            {
                Root = JsonElementToXmlElement(Json.Root)
            };
            return xml;
        }

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
    }
}
