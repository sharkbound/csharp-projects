using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UnturnedModFixer
{
    public class Helper
    {
        public static string[] GetAllFiles()
        {
            string currentDir = Environment.CurrentDirectory;

            return Directory.GetFiles(currentDir, "*.dat", SearchOption.AllDirectories);
            //return Directory.GetFileSystemEntries(currentDir);
        }

        /*public static void AddBypassToFiles(string[] files)
        {
            string results;
            int count = 0;
            
            foreach (var file in files)
            {
                var reader = File.OpenText(file);
                Form1.Log("Opening file.....");
                results = reader.ReadToEnd();

                if (results.Contains("Type Gun"))
                {
                    Form1.Log("Found gun!");
                    count++;
                }
            }
        }*/
    }
}
