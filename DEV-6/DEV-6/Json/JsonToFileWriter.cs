using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DEV_6.Json
{
    /// <summary>
    /// Writes Json to file
    /// </summary>
    class JsonToFileWriter
    {
        private Json Json { get; set; }
        private StreamWriter StreamWriter { get; set; }

        /// <summary>
        /// Writes json element to file
        /// </summary>
        /// <param name="element">Json element to write</param>
        private void WriteElement(JsonElement element)
        {
            StreamWriter.Write($"\"{element.Name}\":");

            if (element.Value != null)
            {
                StreamWriter.Write($"\"{element.Value}\"");
            }
            else
            {
                StreamWriter.WriteLine("{");
                if (IsArray(element.Childrens))
                {
                    WriteChildrensAsArrays(element.Childrens);
                }
                else
                {
                    WriteChildrens(element.Childrens);
                }
                StreamWriter.Write("}");
            }
        }

        /// <summary>
        /// Checks are json element childrens is array
        /// </summary>
        /// <param name="elements">Json element childrens to check</param>
        /// <returns>True if childrens is array</returns>
        private bool IsArray(List<JsonElement> elements)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                for (int j = i + 1; j < elements.Count; j++)
                {
                    if (string.Compare(elements[i].Name, elements[j].Name) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Writes json element childrens as arrays
        /// </summary>
        /// <param name="elements">Json element childrens to write as arrays</param>
        private void WriteChildrensAsArrays(List<JsonElement> elements)
        {
            var arrays = elements.GroupBy(x => x.Name).ToList();
            int countOfArrays = arrays.Count();
            foreach (var array in arrays)
            {
                StreamWriter.Write($"\"{array.Key}\":");
                if (array.Count() > 1)
                {
                    WriteArray(array);
                }
                else
                {
                    WriteElementInArray(array.FirstOrDefault());
                }
                if (countOfArrays > 1)
                {
                    countOfArrays--;
                    StreamWriter.WriteLine(',');
                }
                else
                {
                    StreamWriter.WriteLine();
                }
            }
        }

        /// <summary>
        /// Writes json element childrens as array
        /// </summary>
        /// <param name="elements">Json element childrens to write as array</param>
        private void WriteArray(IGrouping<string, JsonElement> elements)
        {
            StreamWriter.WriteLine('[');
            int childrens = elements.Count();
            foreach (var element in elements)
            {
                WriteElementInArray(element);
                if (childrens > 1)
                {
                    childrens--;
                    StreamWriter.WriteLine(',');
                }
                else
                {
                    StreamWriter.WriteLine();
                }
            }
            StreamWriter.Write("]");
        }

        /// <summary>
        /// Writes json element as member of array to file
        /// </summary>
        /// <param name="element"></param>
        private void WriteElementInArray(JsonElement element)
        {
            if (element.Value != null)
            {
                StreamWriter.Write($"\"{element.Value}\"");
            }
            else
            {
                StreamWriter.WriteLine("{");
                if (IsArray(element.Childrens))
                {
                    WriteChildrensAsArrays(element.Childrens);
                }
                else
                {
                    int childrens = element.Childrens.Count;
                    foreach (JsonElement el in element.Childrens)
                    {
                        WriteElement(el);
                        if (childrens > 1)
                        {
                            childrens--;
                            StreamWriter.WriteLine(',');
                        }
                        else
                        {
                            StreamWriter.WriteLine();
                        }
                    }
                }
                StreamWriter.Write('}');
            }
        }

        /// <summary>
        /// Writes childrens of json element to file
        /// </summary>
        /// <param name="childrens">Childrens of json element to write</param>
        private void WriteChildrens(List<JsonElement> childrens)
        {
            int countOfChildrens = childrens.Count;
            foreach (JsonElement element in childrens)
            {
                WriteElement(element);
                if (countOfChildrens > 1)
                {
                    countOfChildrens--;
                    StreamWriter.Write(",");
                }
                else
                {
                    StreamWriter.WriteLine();
                }
            }
        }

        /// <summary>
        /// Writes Json to file
        /// </summary>
        /// <param name="json">Json to write</param>
        /// <param name="filePath">Path to file</param>
        public void WriteToFile(Json json, string filePath)
        {
            Json = json;
            StreamWriter = new StreamWriter(filePath, true);
            StreamWriter.WriteLine('{');
            WriteElement(Json.Root);
            StreamWriter.WriteLine('}');
            StreamWriter.Dispose();
        }
    }
}
