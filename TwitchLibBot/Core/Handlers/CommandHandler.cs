using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLibBot.Interfaces;
using System.Reflection;
using TwitchLib.Models.Client;
using System.Text.RegularExpressions;
using TwitchLibBot.Core.Helpers;

namespace TwitchLibBot.Core.Handlers
{
    class CommandHandler
    {
        public static void RegisterCommands()
        {
            Commands = from t in Assembly.GetExecutingAssembly().GetTypes()
                       where t.GetInterfaces().Contains(typeof(IChatCommand)) && t.GetConstructor(Type.EmptyTypes) != null
                       select Activator.CreateInstance(t) as IChatCommand;
        }

        internal static IEnumerable<IChatCommand> Commands { get; private set; }


        internal static string[] GetParameters(string chatMsg)
        {
            return Regex.Matches(chatMsg, @"[\""](.+?)[\""]|([^ ]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture).Cast<Match>().Select(x => x.Value.Trim('"').Trim()).ToArray();
        }

        public static void ProcessMessage(ChatMessage chatMsg)
        {
            string msg = chatMsg.Message.ToLower();
            try
            {
                string[] parameters = GetParameters(chatMsg.Message);
                var foundCommand = Commands.FirstOrDefault(c => c.Command == msg.Split().FirstOrDefault());
                foundCommand?.Execute(chatMsg, parameters.Skip(1).ToArray());

                var customCommand = Database.Database.GetCustomCommand(parameters.FirstOrDefault().ToLower());
                if (foundCommand == null && customCommand != null)
                {
                    ChannelChat.Send(ChannelChat.FormatCustomCommandResponse(customCommand.Reponse, chatMsg));
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"An error occured executing a command:\n\nERROR: {e.Message}\n\nSTACKTRACE: \n{e.StackTrace}");
            }
        }
    }
}
