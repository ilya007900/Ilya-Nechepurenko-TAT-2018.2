using System;
using DEV_6.Json;
using DEV_6.Converters;

namespace DEV_6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //if (args.Length != 2)
                //{
                //    throw new ArgumentException("Incorrect parameters");
                //}
                string path = "xFile.xml";
                XmlParser xmlParser = new XmlParser(path);
                XmlToJsonConverter xmlToJsonConverter = new XmlToJsonConverter(xmlParser.Xml);
                Json.Json json = xmlToJsonConverter.GetJson();
                JsonOutputer jsonOutputer = new JsonOutputer(json);
                jsonOutputer.Output();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
