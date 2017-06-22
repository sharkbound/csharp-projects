using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace dotnet47.Methods
{
    class Util
    {
        public static Stopwatch TimeExec(Action func, int times = 1_000)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < times; i++) func();
            sw.Stop();
            return sw;
        }

        public static string PadText(string input, string padding)
        {
            string middle = $"{padding} {input} {padding}";
            string row = string.Concat(Enumerable.Repeat(padding, middle.Length / padding.Length));
            return $"{row}\n{middle}\n{row}";
        }
    }
}
