using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using static dotnet47.Methods.Util;
using System.Numerics;
using System.Threading;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Globalization;

namespace dotnet47
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private void Start()
        {
            IEnumerable<BigInteger> fib(int n = -1, bool continuousYield = false)
            {
                BigInteger cur = 0, nxt = 1;
                int loop = 0;
                while (true)
                {
                    if (n > 0 && loop > n)
                    {
                        yield return cur;
                        break;
                    }

                    if (continuousYield)
                        yield return cur;

                    (cur, nxt) = (cur + nxt, cur);
                    loop++;

                }
            }

            DateTime start = DateTime.Now;
            using (StreamWriter w = new StreamWriter("fibtest.txt"))
            {
                foreach (var f in fib(500_000))
                {
                    w.WriteLine(f);
                }
                w.WriteLine($"\n\n{(DateTime.Now - start).TotalSeconds}");
            }
        }
    }
}
