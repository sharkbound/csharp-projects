using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using DiscordBot2.Utils;
using DiscordBot2.Interfaces;
using System.Reflection;

namespace DiscordBot2.Handlers
{
    
    public class CommandHandler
    {
        public static IEnumerable<IDiscordCommand> Commands;

        private DiscordSocketClient client;
        private char prefix;
        private Logger logger;
        public CommandHandler(DiscordSocketClient c, Logger l, char cmdPrefix)
        {
            client = c;
            prefix = cmdPrefix;
            logger = l;

            Commands = from t in Assembly.GetExecutingAssembly().GetTypes()
                       where t.GetInterfaces().Contains(typeof(IDiscordCommand)) && t.GetConstructor(Type.EmptyTypes) != null
                       select Activator.CreateInstance(t) as IDiscordCommand;

            Console.WriteLine("\n");
            foreach (var command in Commands)
                logger.LogInfo($"Registered command: {command.Name}", ConsoleColor.Green);
            Console.WriteLine("\n");
        }

        public async Task<bool> HandleCommandAsync(SocketMessage socketmsg)
        {
            SocketUserMessage userMsg = socketmsg as SocketUserMessage;
            if (userMsg == null)
                return false;
            
            if (userMsg.Content[0] == prefix)
            {
                List<string> parameters = GetParameters(userMsg, out string cmdName);
                Console.WriteLine(cmdName);
                await Commands.SingleOrDefault(c => c.Name.ToLower() == cmdName).ExecuteAsync(userMsg, parameters);
                return true;
            }
            
            return false;
        }

        public List<string> GetParameters(SocketUserMessage m, out string cmdName)
        {
            cmdName = "null";

            var parameters = m.Content.Split(' ').ToList();
            if (parameters.Count >= 1)
            {
                cmdName = parameters[0].Remove(0, 1).ToLower();
                parameters.Remove(parameters[0]);
            }

            return parameters;
        }
    }
}
