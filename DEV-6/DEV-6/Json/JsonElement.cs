using System.Collections.Generic;

namespace DEV_6.Json
{
    /// <summary>
    /// This class keeps Json element
    /// </summary>
    class JsonElement
    {
        public string Name { get; set; }
        public List<JsonElement> Childrens { get; set; }
        public string Value { get; set; }
    }
}
