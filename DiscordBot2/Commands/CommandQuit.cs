﻿using DiscordBot2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace DiscordBot2.Commands
{
    class CommandQuit : IDiscordCommand
    {
        public string Name => "quit";

        public string Help => "Kills the bot";

        public string Permission => "quit";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            await msg.Channel.SendMessageAsync("**Shutting Down...**");
            await Program.bot.DisconnectAsync();
            Program.cancelSrc.Cancel();
        }
    }
}
