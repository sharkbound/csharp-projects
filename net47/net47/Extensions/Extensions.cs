using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace dotnet47
{
    public static class Extensions
    {
        public static IEnumerable<T> Splice<T>(this IEnumerable<T> arr, int start, int count)
        {
            return arr.Skip(start).Take(count);
        }

        public static void PrintAll<T>(this IEnumerable<T> source, string separator = "")
        {
            Console.WriteLine(string.Join(separator, source));
        }

        public static string Format<T>(this IFindFluent<T, T> i)
        {
            string res = "";
            foreach (var v in i.ToList())
                res += v.ToString()+"\n";
            return res;
        }
    }
}
