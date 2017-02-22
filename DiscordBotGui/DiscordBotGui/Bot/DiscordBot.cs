using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBotGui.Util;
using System.IO;
using DiscordBotGui;
using Discord;
using Discord.Commands;
using System.Threading;

namespace DiscordBotGui.Bot
{
    public class DiscordBotInfo
    {
        public DiscordClient client;
        public CommandService cmdService;
        public BotConfig cfg = new BotConfig();
        public void Init()
        {
            ConfigTool.GetConfigSettings(cfg);
            client = new DiscordClient(c =>
            {
                c.AppName = "sharkbot";
                c.AppVersion = "1.0.0.0";
                c.LogHandler = log;
                c.LogLevel = LogSeverity.Debug;
            });

            client.UsingCommands(c =>
            {
                c.PrefixChar = cfg.CommandPrefix;
                c.AllowMentionPrefix = true;
            });

            client.MessageReceived += (s, e) =>
            {
                Logger.LogInfo(e.Message.Text, e.Channel.Name);
            };

            cmdService = client.GetService<CommandService>();
            registerCommands();

            Task.Factory.StartNew(() =>
            {
                client.ExecuteAndWait(async () =>
                {
                    await client.Connect(cfg.Token, TokenType.Bot);
                });
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        void registerCommands()
        {
            cmdService.CreateCommand("quit")
                .Do(async e =>
                {
                    await e.Channel.SendMessage("**__Swims deep into the ocean...__**");
                    await client.Disconnect();
                });
            cmdService.CreateCommand("me")
                .Do(async e =>
                {
                    await e.Channel.SendMessage("**__i see u__**");
                });
        }

        void log(object sender, LogMessageEventArgs e)
        {
            switch (e.Severity)
            {
                case LogSeverity.Error:
                    Logger.LogError(e.Message, e.Source);
                    break;
                case LogSeverity.Warning:
                    Logger.LogWarning(e.Message, e.Source);
                    break;
                case LogSeverity.Info:
                    Logger.LogInfo(e.Message, e.Source);
                    break;
                case LogSeverity.Verbose:
                    Logger.LogDebug(e.Message, e.Source);
                    break;
                case LogSeverity.Debug:
                    Logger.LogDebug(e.Message, e.Source);
                    break;
            }
        }
    }
}
