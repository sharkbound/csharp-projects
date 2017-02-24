using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBot2.Interfaces;

namespace DiscordBot2.Commands
{
    class CommandPing : IDiscordCommand
    {
        public string Name => "ping";

        public string Help => "Testing if the bot is responsive";

        public async Task ExecuteAsync(SocketUserMessage msg, List<string> parameters)
        {
            await msg.Channel.SendMessageAsync("Pong!");
        }
    }
}
