using System;

namespace DEV_4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = "file.xml";
                XmlFileReader fileReader = new XmlFileReader();
                string stringXml = fileReader.ReadXmlFile(path);
                Console.WriteLine(stringXml);
                Console.WriteLine('\n');
                Xml xml = new Xml(stringXml);
                xml.Output();
                Console.WriteLine('\n');
                xml.Sort();
                xml.Output();
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
