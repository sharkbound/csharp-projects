using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using DiscordBot2.Utils;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Discord.Commands.Builders;
using DiscordBot2.Extensions;
using DiscordBot2.Handlers;
using Discord.Net.Providers.WS4Net;

namespace DiscordBot2
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool botWasQuit = false;
            string errorMsg = "",
                stackTrace = "";
            try
            {
                new Program().Start().GetAwaiter().GetResult();
            }
            catch (TaskCanceledException)
            {
                botWasQuit = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                stackTrace = ex.StackTrace;
            }

            if (!botWasQuit)
            {
                Console.WriteLine($"Error occured that caused the bot to crash!\n\nError Message: {errorMsg}\n\nStacktrace: {stackTrace}");
                Console.ReadKey();
            }
        }

        public static DiscordSocketClient bot;
        public static CancellationTokenSource cancelSrc = new CancellationTokenSource();
        public static Config cfg = Config.GetConfig();
        public static Permissions perms = Permissions.GetPermissions();
        public static CommandHandler commandHandler = new CommandHandler(bot, cfg.CommandPrefix);

        public async Task Start()
        {
            Events.OnCommandExecuted += event_CommandRun;
            Events.OnBotSendMessage += Events_OnBotSendMessage;

            Logger.LogInfo($"Got config values:\n\tCommandPrefix:  {cfg.CommandPrefix}\n\tLogChat:  {cfg.LogChat.ToString()}\n");
            Logger.LogInfo("Starting bot...");
            
            bot = new DiscordSocketClient(new DiscordSocketConfig
            {
                WebSocketProvider = WS4NetProvider.Instance
            });

            await bot.LoginAsync(TokenType.Bot, cfg.Token);
            await bot.ConnectAsync();

            bot.MessageReceived += async msg =>
            {
                try
                {
                    if (msg.Author.Id == bot.CurrentUser.Id)
                        Events.TriggerOnBotSendMessage(msg.Content);

                    if (!await commandHandler.HandleCommandAsync(msg))
                    {
                        // message was not a command
                        if (cfg.LogChat && msg.Author.Id != bot.CurrentUser.Id)
                            Logger.LogChat(msg.Author.Username, msg.Content);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"A error occurned: {ex.Message}\n\n{ex.StackTrace}");
                }
            };

            Logger.LogInfo($"Bot logged in as \n\tUser: {bot.CurrentUser.Username}\n\n", ConsoleColor.Cyan);
            // stop program from closing...
            await Task.Delay(-1, cancelSrc.Token);
        }

        private void Events_OnBotSendMessage(string message)
        {
            Logger.Log($"Sent Message: {message}", ConsoleColor.Magenta);
        }

        private void event_CommandRun(SocketUserMessage msg, SocketUser user, string cmdname, string[] parameters)
        {
            Logger.Log($"{user.Username} ran {msg.Content}", ConsoleColor.Magenta);
        }
    }
}
