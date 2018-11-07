using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_6.Json
{
    class JsonElement
    {
        public string Name { get; set; }
        public List<JsonElement> Childrens { get; set; }
        public string Value { get; set; }
    }
}
