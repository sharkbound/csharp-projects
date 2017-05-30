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
            for (int i = 0; i < times; i++)
            {
                func();
            }
            sw.Stop();
            return sw;
        }
    }
}
