using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace net47
{
    public static class MiscExtensions
    {
        public static IEnumerable<T> Splice<T>(this IEnumerable<T> arr, int start, int count)
        {
            return arr.Skip(start).Take(count);
        }

        public static void PrintAll<T>(this IEnumerable<T> source, string separator = "")
        {
            Console.WriteLine(string.Join(separator, source));
        }

        public static void forEach<T>(this IEnumerable<T> e, Action<T> a)
        {
            foreach (T t in e)
            {
                a(t);
            }
        }

        public static IEnumerable<string> GetAllMatches(this MatchCollection collection, int skip = 0)
        {
            foreach (Match m in collection)
            {
                foreach (var v in m.Groups.Cast<Group>().Select(x => x.Value).Skip(skip))
                {
                    yield return v;
                }
            }
        }
    }
}
