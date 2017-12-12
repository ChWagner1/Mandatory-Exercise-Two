using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logic
{
    internal class FileAccessor
    {
        public string ReadFromFile()
        {
            using (var reader = new StreamReader("serials.txt", Encoding.UTF8, false))
            {
                return reader.ReadToEnd();
            }
        }

        public void WriteToFile(string data)
        {
            using (var writer = new StreamWriter(new FileStream("serials.txt", FileMode.Create), Encoding.UTF8))
            {
                writer.Write(data);
            }
        }
    }
}
