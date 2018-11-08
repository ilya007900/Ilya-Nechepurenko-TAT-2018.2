using System.IO;

namespace DEV_6.Json
{
    class JsonToFileWriter
    {
        private Json Json { get; set; }
        private string FilePath { get; set; }

        public JsonToFileWriter(Json json, string filePath)
        {
            Json = json;
            FilePath = filePath;
        }

        public void WriteToFile()
        {
            WriteElement(Json.Root);
        }

        private void WriteElement(JsonElement element)
        {
            using (StreamWriter streamWriter = new StreamWriter(FilePath, true))
            {
                streamWriter.Write($"\"{element.Name}\":");
            }

            if (element.Value != null)
            {
                using (StreamWriter streamWriter = new StreamWriter(FilePath, true))
                {
                    streamWriter.WriteLine($"\"{element.Value}\"");
                }
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(FilePath, true))
                {
                    streamWriter.WriteLine('{');
                }
                foreach (JsonElement el in element.Childrens)
                {
                    WriteElement(el);
                }
                using (StreamWriter streamWriter = new StreamWriter(FilePath, true))
                {
                    streamWriter.WriteLine('}');
                }
            }
        }
    }
}
