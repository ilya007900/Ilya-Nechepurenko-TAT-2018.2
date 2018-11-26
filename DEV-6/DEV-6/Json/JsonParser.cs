using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_6.Json
{
    /// <summary>
    /// This class parses json string to json
    /// </summary>
    class JsonParser
    {
        private int Position { get; set; }
        private string JsonString { get; set; }
        private static string SymbolsToIgnore { get; } = "\n\r\t";

        /// <summary>
        /// Checks the beginning of the element
        /// </summary>
        /// <returns>true if element is beginning</returns>
        private bool IsElementStarted()
        {
            return JsonString[Position] == '{';
        }

        /// <summary>
        /// Checks the ending of the element
        /// </summary>
        /// <returns>true if element is ending</returns>
        private bool IsElementEnded()
        {
            return JsonString[Position] == '}';
        }

        /// <summary>
        /// Parses string into json element
        /// </summary>
        /// <returns>Json element</returns>
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
            else if (HasChildrens())
            {
                element.Childrens = GetChildrens();
                element.Value = null;
            }
            else
            {
                if (IsStringStartedOrEnded())
                {
                    element.Value = GetStringValue();
                }
                else
                {
                    element.Value = GetValue();
                }
                element.Childrens = null;
            }

            return element;
        }

        /// <summary>
        /// Gets json element name
        /// </summary>
        /// <returns>Json element name</returns>
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

        /// <summary>
        /// Checks childrens of json element
        /// </summary>
        /// <returns>True if json element has childrens</returns>
        private bool HasChildrens()
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

        /// <summary>
        /// Checks is json element is array
        /// </summary>
        /// <returns>True if json element is array</returns>
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

        /// <summary>
        /// Gets childrens of json element
        /// </summary>
        /// <returns>Childrens of json element</returns>
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

        /// <summary>
        /// Checks are childrens of json element is array
        /// </summary>
        /// <returns>True if childrens of json element is array</returns>
        private bool CheckArray()
        {
            int tempPosiion = Position;
            JsonElement tempElement = GetElement();
            Position = tempPosiion;
            if (tempElement == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets array of json element childrens
        /// </summary>
        /// <returns>Array of json element childrens</returns>
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

        /// <summary>
        /// Gets value of json element
        /// </summary>
        /// <returns>Value of json element</returns>
        private string GetValue()
        {
            StringBuilder value = new StringBuilder();
            while (!IsElementEnded() && JsonString[Position] != ',' && !IsArrayEnded())
            {
                if (!SymbolsToIgnore.Contains(JsonString[Position]) && JsonString[Position] != ' ')
                {
                    value.Append(JsonString[Position]);
                }
                Position++;
            }
            return value.ToString();
        }

        /// <summary>
        /// Gets string value of json element
        /// </summary>
        /// <returns>String value of json element</returns>
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

        /// <summary>
        /// Checks the beginning of the array
        /// </summary>
        /// <returns>true if array is beginning</returns>
        private bool IsArrayStarted()
        {
            return JsonString[Position] == '[';
        }

        /// <summary>
        /// Checks the ending of the array
        /// </summary>
        /// <returns>true if array is ending</returns>
        private bool IsArrayEnded()
        {
            return JsonString[Position] == ']';
        }

        /// <summary>
        /// Checks the beginning or ending of the string
        /// </summary>
        /// <returns>true if string is beginning or ending</returns>
        private bool IsStringStartedOrEnded()
        {
            return JsonString[Position] == '"';
        }

        /// <summary>
        /// Parses json string to Json
        /// </summary>
        /// <param name="jsonString">Json string to parse</param>
        /// <returns>Json</returns>
        public Json Parse(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                throw new ArgumentNullException("Json string is null or empty");
            }
            Position = 0;
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

            if (json.Root == null)
            {
                throw new NullReferenceException("Incorrect json file");
            }
            return json;
        }
    }
}
