using DiscordBot2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace DiscordBot2.Commands
{
    class CommandThreaded : ThreadedDiscordCommand
    {
        public override string Name => "thread";

        public override string Help => "";

        public override string Syntax => "";

        public override string Permission => "thread";

        protected override async Task Execute(SocketUserMessage msg, string[] parameters)
        {
            var tmp = await msg.Channel.SendMessageAsync("deleting this message in 5 secoonds...");
            await Task.Delay(5000);
            await tmp.DeleteAsync();
        }
    }
}
