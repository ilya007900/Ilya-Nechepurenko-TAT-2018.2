using System;
using System.IO;

namespace DEV_6.Json
{
    class JsonFileReader
    {
        public string ReadJsonFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                throw new Exception("Can not read file");
            }
            else
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
