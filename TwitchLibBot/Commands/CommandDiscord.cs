using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Models.Client;
using TwitchLibBot.Core.Helpers;
using TwitchLibBot.Interfaces;

namespace TwitchLibBot.Commands
{
    class CommandDiscord : IChatCommand
    {
        public string Command => "!discord";

        public void Execute(ChatMessage msg, string[] parameters)
        {
            Chat.Send("Discord Server: https://discord.gg/5DaYe6j");
        }
    }
}
