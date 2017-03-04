using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Net.WebSockets;
using Discord;
using Discord.WebSocket;

namespace DiscordBot2.Interfaces
{
    public interface IDiscordCommand
    {
        string Name { get; }
        string Help { get; }
        string Syntax { get; }
        string Permission { get; }
        Task ExecuteAsync(SocketUserMessage msg, string[] parameters);
    }
}
