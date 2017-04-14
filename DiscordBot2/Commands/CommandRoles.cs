using DiscordBot2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBot2.Utils;

namespace DiscordBot2.Commands
{
    class CommandRoles : IDiscordCommand
    {
        public string Name => "groups";

        public string Help => "Displays a users roles";

        public string Syntax => "";

        public string Permission => "groups";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            var groups = PermissionHelper.GetUserGroups(msg.Author);
            
            if (groups == null || groups.Count == 0)
            {
                await msg.Channel.SendMessageAsync("You are not in any permission groups!");
            }
            else
            {
                string output = "You are in these permission groups:\n";
                foreach (var g in groups)       
                {
                    output += $"**{g.GroupName}**\n";
                }

                await msg.Channel.SendMessageAsync(output);
            }
        }
    }
}
