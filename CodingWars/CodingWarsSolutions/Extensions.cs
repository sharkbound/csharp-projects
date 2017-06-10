using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWarsSolutions
{
    public static class Extensions
    {
        public static string Format<T>(this IEnumerable<T> src, string separater = ", ", bool enclosingBrackets = true)
        {
            return (enclosingBrackets ? "[" : "") + string.Join(separater, src) + (enclosingBrackets ? "]" : "");
        }
    }
}
