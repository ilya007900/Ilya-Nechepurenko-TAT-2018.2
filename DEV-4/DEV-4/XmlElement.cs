﻿using System.Collections.Generic;

namespace DEV_4
{
    class XmlElement
    {
        public XmlTag Tag { get; set; }
        public List<XmlAttribute> Attributes { get; set; }
        public List<XmlElement> Childrens { get; set; }
        public string Value { get; set; }
    }
}
