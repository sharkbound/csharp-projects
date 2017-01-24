using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.IO;

namespace DirectoryLogger
{
    public class Tools
    {
        string LogFilePath = "DirectoryLog.txt";
        StreamWriter logf;
        public int highestIteration = 0;

        public Process[] GetProcessByName(string pName)
        {
            return Process.GetProcessesByName(pName);
        }

        public long Factorial(int n)
        {
            if (n == 1) return 1;
            return n * Factorial(n - 1);
        }

        public void GetKey(string text = "")
        {
            if (text != "") Console.WriteLine(text);
            Console.ReadKey();
        }

        public string CreateArrow(int length)
        {
            string arrowString = "";
            for (int i = 0; i < length; i++)
                arrowString += "-";
            return arrowString + ">";
        }

        public void PrintFileStructure(string dir, int iteration, int arrowLength)
        {
            if (iteration > highestIteration) highestIteration = iteration;
            foreach (string directory in Directory.GetDirectories(dir))
            {
                Log($"{CreateArrow(arrowLength)} [{directory.CleanPath()}: {iteration}]", true);
                PrintFileStructure(directory, iteration + 1, iteration + 2);
            }
            //Log($"{CreateArrow(arrowLength)} [End of {dir.CleanPath()}]", Log: true);
        }

        public void Log(string text, bool Log = false)
        {
            if (Log) Console.WriteLine(text);
            logf.WriteLine(text);
        }

        public void CreateLogFile()
        {
            if (!File.Exists(LogFilePath)) File.Create(LogFilePath).Dispose();
        }

        public void ConnectToLogFile()
        {
            CreateLogFile();
            logf = File.AppendText(LogFilePath);
        }

        public void CloseLogFileConnection()
        {
            logf.Dispose();
        }

        public void OpenLogFile()
        {
            Process.Start(LogFilePath);
        }

        public void RegenLogFile()
        {
            if (File.Exists(LogFilePath)) File.Delete(LogFilePath);
            CreateLogFile();
        }
    }

    public static class ExtenstionsMethods
    {
        public static string CleanPath(this string path)
        {
            if (!path.Contains(@"\")) return path;
            return path.Remove(0, path.LastIndexOf(@"\") + 1);
        }
    }
}
