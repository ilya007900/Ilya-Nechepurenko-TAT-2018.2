﻿using System;
using System.IO;

namespace DEV_6
{
    /// <summary>
    /// Reads file
    /// </summary>
    class FileReader
    {
        /// <summary>
        /// Reads file in string
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns>file in string</returns>
        /// <exception cref="Exception">Trown if can't read file</exception>
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
