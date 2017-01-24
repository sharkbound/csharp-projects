using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace DirectoryLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var tool = new Tools();

            tool.RegenLogFile();
            tool.ConnectToLogFile();
            tool.PrintFileStructure(Directory.GetCurrentDirectory(), 0, 0);
            tool.CloseLogFileConnection();

            Console.WriteLine($"\n\nFinished going through files! Highest Iteration: {tool.highestIteration}\n\n");
            Console.WriteLine("Do you want to open the log file? \n 1) Y \n 2) N");
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Y:
                    //Console.WriteLine("Current path: " + Directory.GetCurrentDirectory());
                    tool.OpenLogFile();
                    break;
                default:
                    Console.WriteLine("Skipping opening log file...");
                    break;
            }

            tool.GetKey(text: "Press any key to close the application...");
        }
    }

    public static class ExtensionMethods
    {
        public static string CutPath(this string path)
        {
            if (!path.Contains(@"\")) return path;
            return path.Remove(0, path.LastIndexOf(@"\") + 1);
        }
    }
}
