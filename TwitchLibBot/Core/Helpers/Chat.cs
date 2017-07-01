using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Models.Client;
using TwitchLibBot.Data;

namespace TwitchLibBot.Core.Helpers
{
    class Chat
    {
        public static void Send(string msg)
        {
            Program.Bot.SendChat(msg);
        }

        public static string FormatCustomCommandResponse(string s, ChatMessage m)
        {
            return s
                .Replace("%user%", m.DisplayName)
                .Replace("%mention%", $"@{m.DisplayName}")
                ;
        }
    }
}
