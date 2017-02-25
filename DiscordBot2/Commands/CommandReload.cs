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

        public string Permission => "permissions.reload";

        public async Task ExecuteAsync(SocketUserMessage msg, List<string> parameters)
        {
            Program.perms = Permissions.GetPermissions();
            await msg.Channel.SendMessageAsync("Reloaded permissions");
        }
    }
}
