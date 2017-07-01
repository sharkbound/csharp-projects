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
    class CommandCourse : IChatCommand
    {
        public string Command => "!course";

        public void Execute(ChatMessage msg, string[] parameters)
        {
            Chat.Send("Current Java Course: http://mooc.fi/english.html");
        }
    }
}
