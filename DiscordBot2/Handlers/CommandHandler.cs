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
using DiscordBot2.Extensions;

namespace DiscordBot2.Handlers
{

    public class CommandHandler
    {
        public static IEnumerable<IDiscordCommand> Commands;

        private DiscordSocketClient client;
        public string prefix;
        public CommandHandler(DiscordSocketClient c, string cmdPrefix)
        {
            client = c;
            prefix = cmdPrefix;

            Commands = from t in Assembly.GetExecutingAssembly().GetTypes()
                       where t.GetInterfaces().Contains(typeof(IDiscordCommand)) && t.GetConstructor(Type.EmptyTypes) != null
                       select Activator.CreateInstance(t) as IDiscordCommand;

            Console.WriteLine("\n");
            foreach (var command in Commands)
                Logger.LogInfo($"Registered command: {command.Name}", ConsoleColor.Green);
            Console.WriteLine("\n");
        }

        public async Task<bool> HandleCommandAsync(SocketMessage socketmsg)
        {
            SocketUserMessage userMsg = socketmsg as SocketUserMessage;
            if (userMsg == null)
                return false;

            if (userMsg.Content.StartsWith(prefix))
            {
                IDiscordCommand command = null;
                List<string> parameters = GetParameters(userMsg, out string cmdName);

                if (!CommandExist(cmdName, out command))
                {
                    await userMsg.Channel.SendMessageAsync($"{cmdName} is not a valid command");
                    return false;
                }
                else if (!userMsg.Author.HasPermission(command.Permission.ToLower().Trim()))
                {
                    Logger.LogWarning($"denied permission for {prefix}{cmdName} for user {userMsg.Author.Username}");
                    await userMsg.Channel.SendMessageAsync($"You do not have permission to use {prefix}{cmdName}");
                    return false;
                }
                
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
                cmdName = parameters[0].Remove(0, prefix.Length).ToLower();
                parameters.Remove(parameters[0]);
            }

            return parameters;
        }

        public bool CommandExist(string commandName)
        {
            return Commands.SingleOrDefault(c => c.Name.ToLower().Trim() == commandName) != null;
        }

        public bool CommandExist(string commandName, out IDiscordCommand cmd)
        {
            cmd = Commands.SingleOrDefault(c => c.Name.ToLower().Trim() == commandName);
            return cmd != null;
        }
    }
}
