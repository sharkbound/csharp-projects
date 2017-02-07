using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public static class Logger
    {
        public static void LogError(string msg)
        {
            var previousConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(msg);

            Console.ForegroundColor = previousConsoleColor;
        }

        public static void LogInfo(string msg)
        {
            var previousConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(msg);

            Console.ForegroundColor = previousConsoleColor;
        }

        public static void Log(string msg)
        {
            var previousConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(msg);

            Console.ForegroundColor = previousConsoleColor;
        }

        public static void LogWarning(string msg)
        {
            var previousConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(msg);

            Console.ForegroundColor = previousConsoleColor;
        }

        public static void LogDebug(string msg)
        {
            var previousConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(msg);

            Console.ForegroundColor = previousConsoleColor;
        }
    }
}
