using System;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot2.Interfaces;
using Discord.WebSocket;

namespace DiscordBot2.Commands
{
    class CommandTest : IDiscordCommand
    {
        public string Name => "test";

        public string Help => "builds a embed message";

        public string Permission => "test";

        public string Syntax => "...";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            if (parameters.Length < 2 || true) return;

            string targetId = msg.MentionedUsers.Count == 1 ? msg.MentionedUsers.First().Id.ToString() : parameters[0];
            SocketGuild server = ((SocketGuildChannel)msg.Channel).Guild;
            SocketGuildUser target = server.Users.FirstOrDefault(x => x.Id.ToString() == targetId);

            if (target == null)
            {
                await msg.Channel.SendMessageAsync("No users found");
                return;
            }
            
            var allBans = await server.GetBansAsync();
            bool isBanned = allBans.Any(x => x.User.Id == target.Id);

            if (!isBanned)
            {
                var senderHighest = ((SocketGuildUser)msg.Author).Hierarchy;

                if (target.Hierarchy < senderHighest)
                {
                    await server.AddBanAsync(target);
                    await msg.Channel.SendMessageAsync($"**{target.Username}** has been banned by Moderator **{msg.Author}**. Reason: **{String.Join(" ", parameters.Skip(1))}**");

                    try
                    {
                        var dmChannel = await target.GetOrCreateDMChannelAsync();
                        await dmChannel.SendMessageAsync($"You have been banned from **{server.Name}** by Moderator **{msg.Author}** for **{String.Join(" ", parameters.Skip(1))}**");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Failed to send PM to banned user.\nError message: {e.Message}");
                    }
                }
            }
        }
    }
}
