﻿using System;

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
                XmlParser xmlParser = new XmlParser();
                foreach (string str in xmlParser.Parse(stringXml))
                {
                    Console.WriteLine(str);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
