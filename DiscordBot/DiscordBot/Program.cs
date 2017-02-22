using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Net;
using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System.IO;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        DiscordClient bot;
        BotConfig cfg = new BotConfig();

        void Start()
        {
            bot = new DiscordClient(x =>
            {
                x.AppName = "SharkBot";
                x.AppUrl = "http://sharkbound.weebly.com/";
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = log;
            });

            bot.UsingCommands(x =>
            {
                x.PrefixChar = cfg.CommandPrefix;
                x.AllowMentionPrefix = true;
            });

            CreateCommands();

            bot.MessageReceived += async (s, e) =>
            {
                if (bot.Status == UserStatus.Offline 
                || !e.Message.IsAuthor
                || e.Message.Text[0] == cfg.CommandPrefix) return;

                var msg = $"{e.User.Name}: {e.Message.Text}";

                Logger.Log(msg, ConsoleColor.Red);
                await e.Channel.SendMessage(msg);
                await e.User.SendMessage($"You have posted \n\t'{e.Message.Text}' \nin channel \n\t{e.Channel.Name} \nat \n\t{DateTime.Now.ToString()}");
            };

            bot.ExecuteAndWait(async () =>
            {
                await bot.Connect(cfg.Token, TokenType.Bot);
            });
        }

        private void CreateCommands()
        {
            var cmdService = bot.GetService<CommandService>();
            cmdService.CreateCommand("quit")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("**__Swims deep into the ocean...__**");
                    await bot.Disconnect();
                });
        }

        void log(object sender, LogMessageEventArgs e)
        {
            string msg = $"[{e.Severity}] [{e.Source}] {e.Message}";
            switch (e.Severity)
            {
                case LogSeverity.Error:
                    Logger.LogError(msg);
                    break;
                case LogSeverity.Warning:
                    Logger.LogWarning(msg);
                    break;
                case LogSeverity.Info:
                    Logger.LogInfo(msg);
                    break;
                case LogSeverity.Verbose:
                    Logger.Log(msg);
                    break;
                case LogSeverity.Debug:
                    Logger.LogDebug(msg);
                    break;
            }
        }
    }
}
