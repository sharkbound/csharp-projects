using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using DiscordBot2.Utils;

namespace DiscordBot2.Handlers
{
    
    public class CommandHandler
    {
        private DiscordSocketClient client;
        private char prefix;
        private Logger logger;
        public CommandHandler(DiscordSocketClient c, Logger l, char cmdPrefix)
        {
            client = c;
            prefix = cmdPrefix;
            logger = l;
        }

        public async Task<bool> HandleCommandAsync(SocketMessage socketmsg)
        {
            SocketUserMessage userMsg = socketmsg as SocketUserMessage;
            if (userMsg == null)
                return false;
            
            if (userMsg.Content[0] == prefix)
            {
                List<string> parameters = GetParameters(userMsg);

                foreach (var v in parameters)
                {
                    logger.LogWarning(v);
                }
                return true;
            }

            await Task.CompletedTask;
            return false;
        }

        public List<string> GetParameters(SocketUserMessage m)
        {
            var parameters = m.Content.Split(' ').ToList();
            if (parameters.Count > 1)
                parameters.Remove(parameters[0]);
            return parameters;
        }
    }
}
