using System;
using System.IO;

namespace DEV_4
{
    /// <summary>
    /// Reads xml in string
    /// </summary>
    class XmlFileReader
    {
        /// <summary>
        /// Reads and writes xml from file in string
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns>xml in string</returns>
        /// <exception cref="Exception">Trown if can't read file</exception>
        public string ReadXmlFile(string path)
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
