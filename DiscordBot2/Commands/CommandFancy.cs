using DiscordBot2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;
using System.Globalization;
using DiscordBot2.Utils;

namespace DiscordBot2.Commands
{
    class CommandFancy : IDiscordCommand
    {
        public string Name => "say";

        public string Help => "embed test";

        public string Permission => "say";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            if (parameters.Length < 2)
            {
                await msg.Channel.SendMessageAsync("missing parameters");
                return;
            }

            parameters = Command.ReplaceEscapeChars(parameters);

            EmbedBuilder eb = new EmbedBuilder()
            {
                Color = new Color(255, 0, 0)
            };

            eb.AddField(f =>
            {
                f.Name = parameters[0];
                f.Value = parameters[1];
                f.IsInline = true;
            });

            await msg.Channel.SendMessageAsync("", embed: eb.Build());
        }
    }
}
