using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBot2.Utils;
using DiscordBot2.Extensions;
using Discord;
using Discord.WebSocket;

namespace DiscordBot2.Utils
{
    public static class UserVariables
    {
        public static Dictionary<ulong, EmbedBuilder> UserBuilders { get; set; }
    }
}
