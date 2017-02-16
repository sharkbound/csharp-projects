using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AsyncLearning
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
            DateTime start = DateTime.Now;
            Random r = new Random();

            int 
                min = 1,
                max = 5;

            Console.WriteLine("Waiting for all async operations to complete...");

            await Task.WhenAll(
                TimeTaskExecAsync(r.RandomDouble(min, max), "1"),
                TimeTaskExecAsync(r.RandomDouble(min, max), "2"),
                TimeTaskExecAsync(r.RandomDouble(min, max), "3"),
                TimeTaskExecAsync(r.RandomDouble(min, max), "4"));

            CWriteLine($"All async operations finished after {start.GetTotalSecondsElapsed()} seconds!", ConsoleColor.Cyan);
            Pause("Press any key to exit...", ConsoleColor.Red);
        }
    }
}
