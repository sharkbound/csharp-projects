using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCC.Utilites
{
    public class DirUtil
    {
        public static void CreateDirectoryIfNotExist(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        public static void WriteTextToFile(string file, string text)
        {
            File.WriteAllText(file, text);
        }

        public static string ReadTextFile(string file)
        {
            if (File.Exists(file))
            {
                return File.ReadAllText(file);
            }
            else
            {
                throw new FileNotFoundException($"Could not find a file by the name if {file}");
            }
        }
    }
}
