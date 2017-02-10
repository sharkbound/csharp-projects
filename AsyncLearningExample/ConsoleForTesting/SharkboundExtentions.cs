using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ConsoleForTesting
{
    public static class Extentions
    {
        public static string ToDigitsOnly(this string input)
        {
            return Regex.Replace(input, @"[^\d]", "");
        }

        public static string Filter(this string input)
        {
            return Regex.Replace(input, @"test|hi|justme", "");
        }

        public static double GetTotalSecondsElapsed(this DateTime dt)
        {
            return (DateTime.Now - dt).TotalSeconds;
        }
    }
}
