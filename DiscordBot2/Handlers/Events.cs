using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot2.Handlers
{
    public class Events
    {
        public delegate void onCommandRunEventHandler(SocketUserMessage msg, SocketUser user, string commandname, string[] parameters);
        public static event onCommandRunEventHandler OnCommandExecuted;

        public delegate void onBotSendMessageEventHandler(string message);
        public static event onBotSendMessageEventHandler OnBotSendMessage;

        public delegate void onBotShutdownEventHandler();
        public static event onBotShutdownEventHandler OnBotShutdown;

        public static void TriggerOnCommandExecuted(SocketUserMessage msg, SocketUser user, string commandname, string[] parameters)
        {
            OnCommandExecuted?.Invoke(msg, user, commandname, parameters);
        }

        public static void TriggerOnBotSendMessage(string msg)
        {
            OnBotSendMessage?.Invoke(msg);
        }

        public static void TriggerOnBotShutdown()
        {
            OnBotShutdown?.Invoke();
        }
    }
}
