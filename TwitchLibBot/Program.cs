using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Models.API.v5.Users;
using TwitchLib.Events.Client;
using System.Threading;
using TwitchLibBot.Core.Handlers;
using TwitchLibBot.Core.Database;
using TwitchLibBot.Data;

namespace TwitchLibBot
{
    class Program
    {
        internal static TwitchBot Bot { get; private set; }
        
        static void Main(string[] args)
        {
            Config.Load();

            CommandHandler.RegisterCommands();

            foreach (var command in CommandHandler.Commands)
                Console.WriteLine($"Registered Command: {command.Command}");
            
            Bot = new TwitchBot();
            Bot.Connect();
            
            Console.WriteLine("\nPress Shift + X to exit\n\n");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.X && (key.Modifiers & ConsoleModifiers.Shift) != 0)
                {
                    Bot.Disconnect();
                    Thread.Sleep(250);
                    break;
                }
            }
        }
    }
}
