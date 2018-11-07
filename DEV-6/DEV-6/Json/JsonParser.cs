using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_6.Json
{
    class JsonParser
    {
        private int Level { get; set; }
        private int Position { get; set; }
        private string JsonString { get; set; }
        private static string SymbolsToIgnore { get; } = "\n\r\t";

        private Json Parse()
        {
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
            JsonElement element = new JsonElement();

            element.Name = GetElementName();

            if (IsArray())
            {
                element.Childrens = GetChildrens();
                element.Value = null;
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

        public List<JsonElement> GetArray()
        {
            return null;
        } 

        private List<JsonElement> GetChildrens()
        {
            List<JsonElement> childrens = new List<JsonElement>();

            childrens.Add(GetElement());

            while (!IsElementEnded())
            {
                if (JsonString[Position] == ',')
                {
                    childrens.Add(GetElement());
                }
                else
                {
                    Position++;
                }
            }
            Position++;
            return childrens;
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
                while (!IsElementEnded() && JsonString[Position] != ',')
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

        private List<string> GetArrayValue()
        {
            List<string> values = new List<string>();
            StringBuilder value = new StringBuilder();
            while (!IsElementEnded())
            {
                if (JsonString[Position] == '"')
                {
                    value.Append(GetStringValue());
                }
                else if (JsonString[Position] == ',' || JsonString[Position] == ']')
                {
                    values.Add(value.ToString());
                    value.Clear();
                }
                else if (char.IsLetterOrDigit(JsonString[Position])) 
                {
                    value.Append(JsonString[Position]);
                }
                Position++;
            }
            return values;
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

        public Json Json { get; private set; }

        public JsonParser(string path)
        {
            JsonFileReader jsonFileReader = new JsonFileReader();
            JsonString = jsonFileReader.ReadJsonFile(path);
            Json = Parse();
        }
    }
}
