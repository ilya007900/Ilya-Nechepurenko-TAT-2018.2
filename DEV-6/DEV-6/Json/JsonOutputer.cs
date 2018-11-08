using System;

namespace DEV_6.Json
{
    class JsonOutputer
    {
        private Json Json { get; }

        public JsonOutputer(Json json)
        {
            Json = json;
        }

        public void Output()
        {
            OutputElement(Json.Root);
        }

        private void OutputElement(JsonElement element)
        {
            Console.Write($"\"{element.Name}\":");

            if (element.Value != null)
            {
                Console.WriteLine($"\"{element.Value}\"");
            }
            else
            {
                Console.WriteLine("{");
                foreach (JsonElement el in element.Childrens)
                {
                    OutputElement(el);
                }
                Console.WriteLine("}");
            }
        }
    }
}
