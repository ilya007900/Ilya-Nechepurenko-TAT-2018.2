using System;
using System.IO;

namespace DEV_6
{
    class FileReader
    {
        public string ReadFileAsString(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                throw new Exception("Can not read file");
            }
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
