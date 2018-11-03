using System;

namespace DEV_4
{
    /// <summary>
    /// This programm gets xml file from the command line and parses
    /// </summary>
    class MyXmlHandler
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
                XmlParser xmlParser = new XmlParser(path);
                Xml xml = xmlParser.Xml;
                xml.Sort();
                XmlOutputer xmlOutputer = new XmlOutputer(xml);
                xmlOutputer.OutputAsChainOfElements();
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
