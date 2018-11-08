using System.Linq;

namespace DEV_6.Xml
{
    /// <summary>
    /// This class provides methods for sorting xml
    /// </summary>
    class XmlSorter
    {
        private Xml Xml { get; set; }

        /// <summary>
        /// Sorts element
        /// </summary>
        /// <param name="element">Element for sorting</param>
        private void SortElement(XmlElement element)
        {
            if (element.Value != null)
            {
                return;
            }
            else
            {
                foreach (XmlElement el in element.Childrens)
                {
                    SortElement(el);
                }
            }
            SortChildrens(element);
            if (element.Attributes != null)
            {
                SortAttributes(element);
            }
        }

        /// <summary>
        /// Sorts attributes
        /// </summary>
        /// <param name="element">element with attributes</param>
        private void SortAttributes(XmlElement element)
        {
            element.Attributes = (from a in element.Attributes
                                  orderby a.Name, a.Value
                                  select a).ToList();
        }

        /// <summary>
        /// Sorts childrens
        /// </summary>
        /// <param name="element">element with childrens</param>
        private void SortChildrens(XmlElement element)
        {
            element.Childrens.Sort(delegate (XmlElement el1, XmlElement el2)
            {
                if (string.Compare(el1.Tag.Name, el2.Tag.Name) != 0)
                {
                    return string.Compare(el1.Tag.Name, el2.Tag.Name);
                }
                if (el1.Attributes == null && el2.Childrens == null)
                {
                    return 0;
                }
                if (el1.Attributes == null)
                {
                    return -1;
                }
                if (el2.Attributes == null)
                {
                    return 1;
                }
                SortAttributes(el1);
                SortAttributes(el2);
                for (int i = 0; i < el1.Attributes.Count && i < el2.Attributes.Count; i++) 
                {
                    if (string.Compare(el1.Attributes[i].Name, el2.Attributes[i].Name) != 0)
                    {
                        return string.Compare(el1.Attributes[i].Name, el2.Attributes[i].Name);
                    }
                    else if(string.Compare(el1.Attributes[i].Value, el2.Attributes[i].Value) != 0)
                    {
                        return string.Compare(el1.Attributes[i].Value, el2.Attributes[i].Value);
                    }
                }
                return 0;
            });
        }

        public XmlSorter(Xml xml)
        {
            Xml = xml;
        }

        /// <summary>
        /// Sorts xml
        /// </summary>
        public void Sort()
        {
            SortElement(Xml.Root);
        }

    }
}
