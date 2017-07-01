using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Models.Client;

namespace TwitchLibBot.Interfaces
{
    interface IChatCommand
    {
        string Command { get; }
        void Execute(ChatMessage msg, string[] parameters);
    }
}
