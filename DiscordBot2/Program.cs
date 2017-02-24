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
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start().GetAwaiter().GetResult();
        }
        
        Config cfg = Config.GetConfig();
        DiscordSocketClient bot;
        CommandService cmd = new CommandService();
        Logger logger = new Logger();
        CommandHandler commandHandler;

        public async Task Start()
        {
            EmbedBuilder eB = new EmbedBuilder()
            {
                Color = new Color(87, 183, 255),
                Title = "TEST"
            }; //(87,183,255) Ocean blue color

            logger.LogInfo($"Got config values:\nToken:\t{cfg.Token}\nCommandPrefix:\t{cfg.CommandPrefix}");
            logger.LogInfo("Starting bot...");

            bot = new DiscordSocketClient(new DiscordSocketConfig
            {
                WebSocketProvider = WS4NetProvider.Instance
            });

            await bot.LoginAsync(TokenType.Bot, cfg.Token);
            await bot.ConnectAsync();
            
            commandHandler = new CommandHandler(bot, logger, cfg.CommandPrefix);
            bot.MessageReceived += async msg =>
            {
                if (await commandHandler.HandleCommandAsync(msg))
                {

                }
                else
                {

                }
            };

            logger.LogInfo($"Bot logged in as \n\tUser: {bot.CurrentUser.Username}", ConsoleColor.Blue);

            // stop program from closing...
            await Task.Delay(-1);
        }
    }
}
