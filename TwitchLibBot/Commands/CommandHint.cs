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
    class CommandHint : IChatCommand
    {
        public string Command => "!hint";

        public void Execute(ChatMessage msg, string[] parameters)
        {
            ChannelChat.Send("Please do not directly give awnsers, instead hint them towards the awnser/solution.");
        }
    }
}
