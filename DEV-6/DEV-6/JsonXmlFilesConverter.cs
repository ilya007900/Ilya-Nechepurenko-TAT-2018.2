using System;
using DEV_6.Json;
using DEV_6.Converters;
using DEV_6.Xml;

namespace DEV_6
{
    /// <summary>
    /// Converts Json file to Xml file and Xml file to Json file
    /// </summary>
    class JsonXmlFilesConverter
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">File paths</param>
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
                FileReader fileReader = new FileReader();

                if (fileToConvert.Contains(".json"))
                {
                    JsonParser jsonParser = new JsonParser();
                    string jsonString = fileReader.ReadFileAsString(fileToConvert);
                    Json.Json json = jsonParser.Parse(jsonString);
                    JsonToXmlConverter jsonToXmlConverter = new JsonToXmlConverter();
                    Xml.Xml xml = jsonToXmlConverter.Convert(json);
                    XmlToFileWriter xmlToFileWriter = new XmlToFileWriter();
                    xmlToFileWriter.WriteToFile(xml, resultFile);
                }
                else if (fileToConvert.Contains(".xml"))
                {
                    XmlParser xmlParser = new XmlParser();
                    string xmlString = fileReader.ReadFileAsString(fileToConvert);
                    Xml.Xml xml = xmlParser.Parse(xmlString);
                    XmlToJsonConverter xmlToJsonConverter = new XmlToJsonConverter();
                    Json.Json json = xmlToJsonConverter.Convert(xml);
                    JsonToFileWriter jsonToFileWriter = new JsonToFileWriter();
                    jsonToFileWriter.WriteToFile(json, resultFile);
                }
                else
                {
                    throw new Exception("Incorrect parameters");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Incorrect file");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
