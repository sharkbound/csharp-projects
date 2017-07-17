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
    class CommandSandwich : IChatCommand
    {
        public string Command => "!sandwich";

        public void Execute(ChatMessage msg, string[] parameters)
        {
            ChannelChat.Send("I'm a bot, not a personal assistant LUL");
        }
    }
}
