using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using DiscordBot2.Utils;
using DiscordBot2.Extensions;
using DiscordBot2.Interfaces;
using Discord.WebSocket;

namespace DiscordBot2.Commands
{
    class CommandBuild : IDiscordCommand
    {
        public string Name => "build";

        public string Help => "builds a embed message";

        public string Permission => "build";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            try
            {
                if (UserVariables.UserBuilders == null) UserVariables.UserBuilders = new Dictionary<ulong, EmbedBuilder>();
                if (!UserVariables.UserBuilders.ContainsKey(msg.Author.Id))
                    UserVariables.UserBuilders.Add(msg.Author.Id, new EmbedBuilder());

                if (parameters.Length == 0)
                {
                    await msg.Channel.SendMessageAsync("missing parameters");
                }

                switch (parameters[0].ToLower())
                {
                    case "add":
                        if (parameters.Length != 4)
                        {
                            await msg.Channel.SendMessageAsync("The add parameters requires 3 parameters after it\n" +
                                "Add Parameters: <nl || cl> <\"heading text\"> <\"bodytext\">");
                            break;
                        }

                        UserVariables.UserBuilders[msg.Author.Id].AddField(e =>
                        {
                            e.Name = parameters[2];
                            e.Value = parameters[3];
                            if (parameters[1].ToLower() == "cl")
                                e.IsInline = true;
                            else
                                e.IsInline = false;
                        });
                        break;
                    case "say":
                        await msg.Channel.SendMessageAsync("", embed: UserVariables.UserBuilders[msg.Author.Id].Build());
                        break;
                    case "clear":
                        UserVariables.UserBuilders[msg.Author.Id] = new EmbedBuilder();
                        await msg.Channel.SendMessageAsync("Cleared your built message");
                        break;
                    default:
                        await msg.Channel.SendMessageAsync("Entered parameters were invalid\nValid parameters:\nadd\nsay\nclear");
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }
    }
}
