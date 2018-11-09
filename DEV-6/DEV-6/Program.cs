using System;
using DEV_6.Json;
using DEV_6.Converters;
using DEV_6.Xml;

namespace DEV_6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    throw new ArgumentException("Incorrect parameters");
                }

                string fileToConvert = args[0];
                string resultFile = args[1];

                if (fileToConvert.Contains(".json"))
                {
                    JsonParser jsonParser = new JsonParser(fileToConvert);
                    Json.Json json = jsonParser.Json;
                    JsonToXmlConverter jsonToXmlConverter = new JsonToXmlConverter(json);
                    Xml.Xml xml = jsonToXmlConverter.Xml;
                    XmlToFileWriter xmlToFileWriter = new XmlToFileWriter(xml);
                    xmlToFileWriter.WriteToFile(resultFile);
                    XmlOutputer xmlOutputer = new XmlOutputer(xml);
                    xmlOutputer.OutputAsXml();
                }
                else if (fileToConvert.Contains(".xml"))
                {
                    XmlParser xmlParser = new XmlParser(fileToConvert);
                    Xml.Xml xml = xmlParser.Xml;
                    XmlToJsonConverter xmlToJsonConverter = new XmlToJsonConverter(xml);
                    Json.Json json = xmlToJsonConverter.Json;
                    JsonOutputer jsonOutputer = new JsonOutputer(json);
                    jsonOutputer.Output();
                    JsonToFileWriter jsonToFileWriter = new JsonToFileWriter(json);
                    jsonToFileWriter.WriteToFile(resultFile);
                }
                else
                {
                    throw new Exception("Incorrect parameters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
