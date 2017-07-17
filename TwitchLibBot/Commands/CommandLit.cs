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
    class CommandLit : IChatCommand
    {
        public string Command => "!lit";

        static Random r = new Random();
        static string[] emotes = new[] { "CurseLit", "TwitchLit" };

        public void Execute(ChatMessage msg, string[] parameters)
        {
            string message = "";
            for (int i = 0; i < 7; i++)
                message += $"{emotes[r.Next(emotes.Length)]} ";

            ChannelChat.Send(message);
        }
    }
}
