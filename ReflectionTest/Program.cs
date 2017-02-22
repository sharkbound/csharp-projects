using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDir = Directory.GetCurrentDirectory(),
                rocketUnturnedPath = @"C:\Users\owner\Desktop\GitHub\csharp-projects\ReflectionTest\assemblies\Rocket.Core.dll";

            Assembly rocketDll = Assembly.LoadFile(rocketUnturnedPath);
            string json = JsonConvert.SerializeObject(rocketDll, Formatting.Indented);
            Console.WriteLine(json);
            File.Delete("output.json");
            File.AppendAllText("output.json", json);
            Process.Start("output.json");

            try
            {
                foreach (Type type in rocketDll.GetTypes())
                {
                    try
                    {
                        Console.WriteLine("TYPE: " + type.Name);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
