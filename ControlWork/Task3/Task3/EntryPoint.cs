using System;
using System.Xml.Linq;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 0)
                {
                    throw new ArgumentException("Incorrect parameters");
                }
                string file = "file.xml";
                XDocument xdoc = XDocument.Load(file);
                List<Product> products = new List<Product>();
                foreach (XElement productElement in xdoc.Element("products").Elements("product"))
                {
                    XAttribute type = productElement.Attribute("type");
                    XAttribute price = productElement.Attribute("Price");
                    XAttribute name = productElement.Attribute("Name");
                    XAttribute date = productElement.Attribute("Date");

                    products.Add(new Product
                    {
                        Type = type.Value,
                        Name = name.Value,
                        Price = price.Value,
                        Date = date.Value
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
