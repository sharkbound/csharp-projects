using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DiscordBotGui.Util
{
    public class Logger
    {
        public static void ClearLogs()
        {
            MainWindow.table.Rows.Clear();
        }

        public static void Log(params object[] obj)
        {
            MainWindow.table.Rows.Add(obj);
        }

        public static void Log(string source, string type, string user, string message)
        {
            MainWindow.table.Rows.Add(source, type, user, message);
        }

        public static void LogDebug(string message, string source)
        {
            MainWindow.table.Rows.Add(source, "DEBUG", "BOT", message);
        }

        public static void LogInfo(string message, string source)
        {
            MainWindow.table.Rows.Add(source, "INFO", "BOT", message);
        }

        public static void LogWarning(string message, string source)
        {
            MainWindow.table.Rows.Add(source, "WARNING", "BOT", message);
        }

        public static void LogError(string message, string source)
        {
            MainWindow.table.Rows.Add(source, "ERROR", "BOT", message);
        }
    }
}
