using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Models.Client;
using TwitchLibBot.Core.Handlers;
using TwitchLibBot.Core.Helpers;
using TwitchLibBot.Interfaces;

namespace TwitchLibBot.Commands
{
    class CommandHelp : IChatCommand
    {
        public string Command => "!help";

        public void Execute(ChatMessage msg, string[] parameters)
        {
            string commands = "Commands:  " + string.Join(", ", CommandHandler.Commands.Select(x => x.Command));
            ChannelChat.Send(commands);
        }
    }
}
