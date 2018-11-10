using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_6.Json
{
    class JsonOutputer
    {
        private Json Json { get; set; }

        public JsonOutputer() { }

        public void Output(Json json)
        {
            Json = json;
            Console.WriteLine('{');
            OutputElement(Json.Root);
            Console.WriteLine("}");
        }

        private void OutputElement(JsonElement element)
        {
            Console.Write($"\"{element.Name}\":");

            if (element.Value != null)
            {
                Console.Write($"\"{element.Value}\"");
            }
            else
            {
                Console.WriteLine("{");
                if (IsArray(element.Childrens))
                {
                    OutputChildrensAsArrays(element.Childrens);
                }
                else
                {
                    OutputChildrens(element.Childrens);
                }
                Console.WriteLine("}");
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

        private void OutputChildrensAsArrays(List<JsonElement> elements)
        {
            var arrays = elements.GroupBy(x => x.Name).ToList();
            int countOfArrays = arrays.Count();
            foreach (var array in arrays)
            {
                Console.Write($"\"{array.Key}\":");
                if (array.Count() > 1)
                {
                    OutputArray(array);
                }
                else
                {
                    OutputElementInArray(array.FirstOrDefault());
                }
                if (countOfArrays > 1)
                {
                    countOfArrays--;
                    Console.WriteLine(',');
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        private void OutputElementInArray(JsonElement element)
        {
            if (element.Value != null)
            {
                Console.Write($"\"{element.Value}\"");
            }
            else
            {
                Console.WriteLine("{");
                if (IsArray(element.Childrens))
                {
                    OutputChildrensAsArrays(element.Childrens);
                }
                else
                {
                    int childrens = element.Childrens.Count;
                    foreach (JsonElement el in element.Childrens)
                    {
                        OutputElement(el);
                        if (childrens > 1)
                        {
                            childrens--;
                            Console.WriteLine(',');
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                }
                Console.Write("}");
            }
        }

        private void OutputChildrens(List<JsonElement> childrens)
        {
            int countOfChildrens = childrens.Count;
            foreach (JsonElement el in childrens)
            {
                OutputElement(el);
                if (countOfChildrens > 1)
                {
                    countOfChildrens--;
                    Console.WriteLine(',');
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        private void OutputArray(IGrouping<string, JsonElement> elements)
        {
            Console.WriteLine("[");
            int childrens = elements.Count();
            foreach (var element in elements)
            {
                OutputElementInArray(element);
                if (childrens > 1)
                {
                    childrens--;
                    Console.WriteLine(',');
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.Write("]");
        }
    }
}
