using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot2.Utils
{
    public class Logger
    {
        public void Log(string msg, ConsoleColor color = ConsoleColor.Gray)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = oldColor;
        }

        public void LogInfo(string msg) =>
            Log($"INFO: {msg}", ConsoleColor.White);
        
        public void LogInfo(string msg, ConsoleColor color) =>
            Log($"INFO: {msg}", color);

        public void LogWarning(string msg) =>
            Log($"WARNING: {msg}", ConsoleColor.Yellow);

        public void LogError(string msg) =>
            Log($"ERROR: {msg}", ConsoleColor.Red);

        public void LogDebug(string msg) =>
            Log($"DEBUG: {msg}", ConsoleColor.Blue);
    }
}
