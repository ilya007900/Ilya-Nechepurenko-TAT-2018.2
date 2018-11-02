using System;

namespace DEV_4
{
    /// <summary>
    /// This programm gets file from the command line and parses
    /// </summary>
    class MyXmlHandler
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Arguments from the command line</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 1)
                {
                    throw new ArgumentException("Not enough parameters");
                }
                if (args.Length > 1)
                {
                    throw new ArgumentException("Too many parameters");
                }

                string path = args[0];
                XmlParser xmlParser = new XmlParser(path);
                Xml xml = xmlParser.Xml;
                xml.Sort();
                XmlOutputer xmlOutputer = new XmlOutputer(xml);
                xmlOutputer.OutputAsChainOfElements();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Incorrect Xml file");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
