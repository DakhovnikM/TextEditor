using System;
using System.IO;
using System.Text;

namespace TextEditor.BL
{
    public class FileManager
    {
        private readonly Encoding defaultEncoding = Encoding.GetEncoding(1251);

        public string GetString(string filePath)
        {
            return GetString(filePath, defaultEncoding);
        }

        public string GetString(string filePath, Encoding encoding)
        {
            var content = File.ReadAllText(filePath, encoding);

            return content;
        }

    }
}
