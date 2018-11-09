using System.Collections.Generic;
using System.Text;

namespace DEV_6.Json
{
    class JsonParser
    {
        private int Position { get; set; }
        private string JsonString { get; set; }
        private static string SymbolsToIgnore { get; } = "\n\r\t";
        
        private bool IsElementStarted()
        {
            if (JsonString[Position] == '{')
            {
                return true;
            }
            return false;
        }

        private bool IsElementEnded()
        {
            if (JsonString[Position] == '}')
            {
                return true;
            }
            return false;
        }

        private JsonElement GetElement()
        {
            JsonElement element = new JsonElement
            {
                Name = GetElementName()
            };
            if (IsArray())
            {
                return null;
            }
            else if (HaveChildrens())
            {
                element.Childrens = GetChildrens();
                element.Value = null;
            }
            else
            {
                element.Value = GetValue();
                element.Childrens = null;
            }

            return element;
        }

        private string GetElementName()
        {
            StringBuilder name = new StringBuilder();

            while (JsonString[Position] != '"')
            {
                Position++;
            }
            Position++;
            while (JsonString[Position] != '"')
            {
                name.Append(JsonString[Position]);
                Position++;
            }
            Position++;
            return name.ToString();
        }

        private bool HaveChildrens()
        {
            while (true)
            {
                if (IsElementStarted())
                {
                    return true;
                }
                else if (char.IsLetterOrDigit(JsonString[Position]) || IsStringStartedOrEnded()) 
                {
                    return false;
                }
                Position++;
            }
        }

        private bool IsArray()
        {
            while (true)
            {
                if (JsonString[Position] == '[')
                {
                    return true;
                }
                else if (IsElementStarted() || IsStringStartedOrEnded() || char.IsLetterOrDigit(JsonString[Position]))
                {
                    return false;
                }
                Position++;
            }
        }

        private List<JsonElement> GetChildrens()
        {
            {
                List<JsonElement> childrens = new List<JsonElement>();

                if (CheckArray())
                {
                    childrens.AddRange(GetArray());
                }
                else
                {
                    childrens.Add(GetElement());
                }

                while (!IsElementEnded())
                {
                    if (JsonString[Position] == ',')
                    {
                        if (CheckArray())
                        {
                            childrens.AddRange(GetArray());
                        }
                        else
                        {
                            childrens.Add(GetElement());
                        }
                    }
                    else
                    {
                        Position++;
                    }
                }
                Position++;
                return childrens;
            }
        }

        private bool CheckArray()
        {
            int tempPosiion = Position;
            JsonElement tempElement = GetElement();
            if(tempElement == null)
            {
                Position = tempPosiion;
                return true;
            }
            Position = tempPosiion;
            return false;
        }

        private List<JsonElement> GetArray()
        {
            List<JsonElement> values = new List<JsonElement>();
            string name = GetElementName();
            while (!IsArrayEnded())
            {
                if (IsElementStarted())
                {
                    values.Add(new JsonElement
                    {
                        Childrens = GetChildrens(),
                        Name = name,
                        Value = null
                    });
                }
                else if (IsStringStartedOrEnded())
                {
                    values.Add(new JsonElement
                    {
                        Childrens = null,
                        Name = name,
                        Value = GetStringValue()
                    });
                }
                else if (char.IsLetterOrDigit(JsonString[Position]))
                {
                    values.Add(new JsonElement
                    {
                        Childrens = null,
                        Name = name,
                        Value = GetValue()
                    });
                }
                else
                {
                    Position++;
                }
            }
            return values;
        }

        private string GetValue()
        {

            if (JsonString[Position] == '"')
            {
                return GetStringValue();
            }
            else
            {
                StringBuilder value = new StringBuilder();
                while (!IsElementEnded() && JsonString[Position] != ',' && JsonString[Position] != ']')
                {
                    if (!SymbolsToIgnore.Contains(JsonString[Position]) && JsonString[Position] != ' ') 
                    {
                        value.Append(JsonString[Position]);
                    }
                    Position++;
                }
                return value.ToString();
            }
        }

        private string GetStringValue()
        {
            StringBuilder value = new StringBuilder();
            Position++;
            while (JsonString[Position] != '"')
            {
                value.Append(JsonString[Position]);
                Position++;
            }
            Position++;
            return value.ToString();
        }

        private bool IsArrayStarted()
        {
            if (JsonString[Position] == '[')
            {
                return true;
            }
            return false;
        }

        private bool IsArrayEnded()
        {
            if (JsonString[Position] == ']')
            {
                return true;
            }
            return false;
        }

        private bool IsStringStartedOrEnded()
        {
            if (JsonString[Position] == '"')
            {
                return true;
            }
            return false;
        }

        public JsonParser() { }

        public Json Parse(string jsonString)
        {
            JsonString = jsonString;
            Json json = new Json();

            while (Position < JsonString.Length)
            {
                if (IsElementStarted())
                {
                    json.Root = GetElement();
                }
                Position++;
            }

            return json;
        }
    }
}
