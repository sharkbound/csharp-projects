using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBot2.Interfaces;
using DiscordBot2.Handlers;

namespace DiscordBot2.Commands
{
    class CommandHelp : IDiscordCommand
    {
        public string Name => "help";

        public string Help => "Shows all commands";

        public async Task ExecuteAsync(SocketUserMessage msg, List<string> parameters)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var cmd in CommandHandler.Commands)
            {
                sb.AppendLine($"{cmd.Name} : {cmd.Help}");
            }

            await msg.Author.CreateDMChannelAsync().GetAwaiter().GetResult().SendMessageAsync(sb.ToString());
            await msg.Channel.SendMessageAsync($"@{msg.Author.Username} Sent you a help DM.");
        }
    }
}
