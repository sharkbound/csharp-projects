using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleForTesting
{
    class Program
    {
        static Regex REG = new Regex(@"[^\d]", RegexOptions.Compiled);
        public static void Main(string[] args)
        {
            new NonStaticMain().RunAsync().Wait();
        }
    }

    class NonStaticMain : Methods
    {
        public async Task RunAsync()
        {
            Console.WriteLine("Waiting for all async operations to complete...");

            DateTime start = DateTime.Now;
            await Task.WhenAll(
                TimeTaskExecAsync(1.75, "1"),
                TimeTaskExecAsync(0.5, "2"),
                TimeTaskExecAsync(0.6, "3"),
                TimeTaskExecAsync(0.891, "4"));

            CWriteLine($"All async operations finished after {start.GetTotalSecondsElapsed()} seconds!", ConsoleColor.Cyan);
            Pause("Press any key to exit...", ConsoleColor.Red);
        }
    }
}
