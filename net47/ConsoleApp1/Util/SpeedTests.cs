using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.IO;

namespace Core.Util
{
    class SpeedTests
    {
        private static BigInteger fib(int n)
        {
            BigInteger cur = 0; BigInteger nxt = 1;
            while (n > 0)
            {
                (cur, nxt) = (cur + nxt, cur);
                n--;
            }
            return cur;
        }

        public static void TimeFib()
        {
            Console.WriteLine("starting...");
            DateTime s = DateTime.Now;
            File.WriteAllText("core.txt", $"{fib(500000)}\n{(DateTime.Now - s).TotalSeconds}");
        }
    }
}
