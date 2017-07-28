using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net47.Extensions
{
    public static class ArrayExtensions
    {
        public static string ConvertToString(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
