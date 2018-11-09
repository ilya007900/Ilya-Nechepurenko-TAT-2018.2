using System.IO;

namespace DEV_6.Xml
{
    class XmlToFileWriter
    {
        private Xml Xml { get; set; }
        private StreamWriter StreamWriter { get; set; }

        public XmlToFileWriter() { }

        public void WriteToFile(Xml xml, string filePath)
        {
            Xml = xml;
            StreamWriter = new StreamWriter(filePath, true);
            WriteElement(Xml.Root);
            StreamWriter.Dispose();
        }

        private void WriteElement(XmlElement element)
        {
            StreamWriter.Write($"<{element.Tag.Name}");

            if (element.Attributes != null)
            {
                foreach (XmlAttribute attribute in element.Attributes)
                {
                    StreamWriter.Write($" {attribute.Name}=\"{attribute.Value}\"");
                }
            }
            StreamWriter.Write('>');
            if (element.Value != null)
            {
                StreamWriter.WriteLine($"{element.Value}</{element.Tag.Name}>");
            }
            else
            {
                StreamWriter.WriteLine();
                foreach (XmlElement el in element.Childrens)
                {
                    WriteElement(el);
                }
                StreamWriter.WriteLine($"</{element.Tag.Name}>");
            }
        }
    }
}
