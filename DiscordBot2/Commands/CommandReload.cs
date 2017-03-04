using DiscordBot2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace DiscordBot2.Commands
{
    class CommandReload : IDiscordCommand
    {
        public string Name => "reload";

        public string Help => "reloads permissions";

        public string Permission => "p.reload";

        public string Syntax => "";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Program.perms = Permissions.GetPermissions();
            await msg.Channel.SendMessageAsync("Reloaded permissions");
        }
    }
}
