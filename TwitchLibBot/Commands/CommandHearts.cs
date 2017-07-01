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
    class CommandHearts : IChatCommand
    {
        public string Command => "!hearts";

        static Random r = new Random();
        string[] emotes = new[] { "TwitchUnity", "<3", "bleedPurple" };

        public void Execute(ChatMessage msg, string[] parameters)
        {
            string message = "";
            for (int i = 0; i < 7; i++)
                message += $"{emotes[r.Next(emotes.Length)]} ";

            Chat.Send(message);
        }
    }
}
