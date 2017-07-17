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
    public class CommandCustoms : IChatCommand
    {
        public string Command => "!customs";

        public void Execute(ChatMessage msg, string[] parameters)
        {
            string message = "Custom Commands: ";
            foreach (var c in Core.Database.Database.CommandDB.FindAll())
            {
                message += $"{c.CmdName}, ";
            }
            ChannelChat.Send(message == "Custom Commands: " ? "No Custom Commands Found" : message);
        }
    }
}
