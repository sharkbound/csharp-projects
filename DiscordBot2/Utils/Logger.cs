using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot2.Utils
{
    public class Logger
    {
        public static void Log(string msg, ConsoleColor color = ConsoleColor.Gray)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = oldColor;
        }


        public static void LogChat(string author, string msg, ConsoleColor color = ConsoleColor.White)
        {
            var now = DateTime.Now;
            Log($"[{now.Minute}:{now.Second}] {author}: {msg}", color);
        }

        public static void LogInfo(string msg) =>
            Log($"INFO: {msg}", ConsoleColor.White);

        public static void LogInfo(string msg, ConsoleColor color) =>
            Log($"INFO: {msg}", color);

        public static void LogWarning(string msg) =>
            Log($"WARNING: {msg}", ConsoleColor.Yellow);

        public static void LogError(string msg) =>
            Log($"ERROR: {msg}", ConsoleColor.Red);

        public static void LogDebug(string msg) =>
            Log($"DEBUG: {msg}", ConsoleColor.Blue);
    }
}
