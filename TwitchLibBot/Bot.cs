using System;
using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Models.API.v5.Users;
using TwitchLib.Events.Client;
using TwitchLibBot.Core.Handlers;
using TwitchLib.Services;
using TwitchLibBot.Data;
using System.Linq;
using TwitchLibBot.Core.Helpers;

namespace TwitchLibBot
{
    internal class TwitchBot
    {
        readonly ConnectionCredentials credentials = new ConnectionCredentials(Config.Instance.BotNickName, Config.Instance.Oauth);
        public TwitchClient client;
        
        internal void Connect()
        {
            client = new TwitchClient(credentials, Config.Instance.ChannelName, logging: false)
            {
                ChatThrottler = new MessageThrottler(10, TimeSpan.FromSeconds(30)),
                WhisperThrottler = new MessageThrottler(10, TimeSpan.FromSeconds(30))
            };

            client.OnLog += Client_OnLog;
            client.OnConnectionError += Client_OnConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnMessageSent += Client_OnMessageSent;
            client.OnWhisperSent += Client_OnWhisperSent;

            Console.WriteLine($"Connecting to channel {Config.Instance.ChannelName} as {Config.Instance.BotNickName}");

            client.Connect();
        }

        private void Client_OnWhisperSent(object sender, OnWhisperSentArgs e)
        {
            Console.WriteLine($"SENT PM >>> {e.Receiver} -> {e.Message}");
        }

        private void Client_OnMessageSent(object sender, OnMessageSentArgs e)
        {
            Console.WriteLine($"{Config.Instance.ChannelName} >>> {e.SentMessage.Message}");
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