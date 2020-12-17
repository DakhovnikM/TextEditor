using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TextEditor.BL
{
    public class FileManager
    {
        private readonly Encoding defaultEncoding = Encoding.UTF8;

        public string GetString(string filePath)
        {
            return GetString(filePath, defaultEncoding);
        }

        public string GetString(string filePath, Encoding encoding)
        {
            var str = File.ReadAllText(filePath, encoding);

            return str;
        }

        public void SaveString(string filePath, string content)
        {
            SaveString(filePath, content, defaultEncoding);
        }

        public void SaveString(string filePath, string content, Encoding encoding)
        {
            if (File.Exists(filePath))
                File.WriteAllText(filePath, content, encoding);
            else 
                throw new FileNotFoundException(filePath);
        }

        public int GetSimbolCount(string count)
        {
            return count.Length;
        }
    }
}
