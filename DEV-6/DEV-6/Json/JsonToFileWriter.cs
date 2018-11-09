using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DEV_6.Json
{
    class JsonToFileWriter
    {
        private Json Json { get; set; }
        private StreamWriter StreamWriter { get; set; }

        public JsonToFileWriter() { }

        public void WriteToFile(Json json, string filePath)
        {
            Json = json;
            StreamWriter = new StreamWriter(filePath, true);
            StreamWriter.WriteLine('{');
            WriteElement(Json.Root);
            StreamWriter.WriteLine('}');
            StreamWriter.Dispose();
        }

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

        private bool IsArray(List<JsonElement> elements)
        {
            if (elements.Where(x => x.Name == elements.FirstOrDefault().Name).Count() > 1)
            {
                return true;
            }
            return false;
        }

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
    }
}
