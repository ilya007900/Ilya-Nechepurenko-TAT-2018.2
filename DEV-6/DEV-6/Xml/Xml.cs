﻿
namespace DEV_6.Xml
{
    /// <summary>
    /// This class keeps xml
    /// </summary>
    class Xml
    {
        public XmlElement Root { get; set; }

        public void Sort()
        {
            XmlSorter xmlSorter = new XmlSorter(this);
            xmlSorter.Sort();
        }  
    }
}
