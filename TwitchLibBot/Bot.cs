using System;
using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Models.API.v5.Users;
using TwitchLib.Events.Client;
using TwitchLibBot.Data.Resources;
using TwitchLibBot.Core.Handlers;
using TwitchLib.Services;

namespace TwitchLibBot
{
    internal class TwitchBot
    {
        readonly ConnectionCredentials credentials = new ConnectionCredentials(TwitchInfo.Nick, TwitchInfo.Oauth);
        public TwitchClient client;
        
        internal void Connect()
        {
            client = new TwitchClient(credentials, TwitchInfo.ChannelName, logging: false)
            {
                ChatThrottler = new MessageThrottler(10, TimeSpan.FromSeconds(30)),
                WhisperThrottler = new MessageThrottler(10, TimeSpan.FromSeconds(30))
            };

            client.OnLog += Client_OnLog;
            client.OnConnectionError += Client_OnConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;

            Console.WriteLine($"Connecting to channel {TwitchInfo.ChannelName} as {TwitchInfo.Nick}");

            client.Connect();
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            Console.WriteLine($"CHAT({e.ChatMessage.Channel}) {e.ChatMessage.Username}: {e.ChatMessage.Message}");
            CommandHandler.ProcessMessage(e.ChatMessage);
        }

        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine($"ERROR!! {e.Error}");
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            //Console.WriteLine($"LOG: {e.Data}");
        }

        internal void Disconnect()
        {
            client.Disconnect();
        }

        internal void SendChat(string msg)
        {
            client.SendMessage(msg);
        }
    }
}