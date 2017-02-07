using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ConsoleForTesting
{
    class Program
    {
        static Regex REG = new Regex(@"[^\d]", RegexOptions.Compiled);
        static void Main(string[] args)
        {

            Console.WriteLine(REG.Replace("abc-123+456->789", "#"));
            Console.WriteLine("Press any key to exit..."); 
            Console.ReadKey();
        }
    }

    public static class EXT
    {
        public static string ToDigitsOnly(this string input)
        {
            return Regex.Replace(input, @"[^\d]", "");
        }

        public static string Filter(this string input)
        {
            return Regex.Replace(input, @"test|hi|justme", "");
        }
    }
}
