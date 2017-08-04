using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBot2.Interfaces;

namespace DiscordBot2.Commands
{
    class CommandEB : IDiscordCommand
    {
        public string Name => "pika";

        public string Help => "";

        public string Syntax => "";

        public string Permission => "eb";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.AddField("hello world!", "hello :)", inline: true);
            eb.AddField("hello world!", "hello :)", inline: true);
            eb.WithImageUrl("https://vignette2.wikia.nocookie.net/steven-universe/images/2/25/Pikachu_waving.gif/revision/latest?cb=20151224010309");
            eb.WithImageUrl("https://vignette2.wikia.nocookie.net/steven-universe/images/2/25/Pikachu_waving.gif/revision/latest?cb=20151224010309");
            //eb.ImageUrl = @"https://vignette2.wikia.nocookie.net/steven-universe/images/2/25/Pikachu_waving.gif/revision/latest?cb=20151224010309";
            await msg.Channel.SendMessageAsync("", embed: eb);
        }
    }
}
