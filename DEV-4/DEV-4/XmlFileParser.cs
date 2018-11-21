using System;

namespace DEV_4
{
    /// <summary>
    /// This programm gets xml file from the command line and parses
    /// </summary>
    class XmlFileParser
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">first parameter is path to file</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new ArgumentException("Incorrect parameters");
                }
                string path = args[0];
                FileReader fileReader = new FileReader();
                string xmlString = fileReader.ReadFile(path);
                XmlParser xmlParser = new XmlParser();
                Xml xml = xmlParser.Parse(xmlString);
                XmlSorter xmlSorter = new XmlSorter();
                xmlSorter.Sort(xml);
                XmlOutputer xmlOutputer = new XmlOutputer();
                xmlOutputer.OutputAsChainOfElements(xml);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Incorrect Xml file");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
