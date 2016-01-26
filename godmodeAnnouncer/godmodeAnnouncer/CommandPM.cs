using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;

namespace godmodeAnnouncer
{
    class CommandPM : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>() {"message"}; }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Both; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer otherUplayer = UnturnedPlayer.FromName(command[0]);
            if (otherUplayer == null)
            {
                if (caller is ConsolePlayer)
                {
                    Logger.Log("player not found");
                    return;
                }
                else
                {
                    UnturnedChat.Say(caller, "player not found");
                    return;
                }
            }

            if (command.Length <= 1)
            {
                UnturnedChat.Say(caller, "incorrect usage. /pm <playerName> (message)");
            }

            if (caller is ConsolePlayer)
            {
                string message = "";

                for (int ii = 1; ii <= (command.Length - 1); ii++){
                    message += " " + command[ii];
                }

                UnturnedChat.Say(otherUplayer, "Console has whispered to you:" + message);
                UnturnedChat.Say(caller, "pm sent to " + otherUplayer.DisplayName);
            }
            else
            {
                string message = "";

                for (int ii = 1; ii <= (command.Length - 1); ii++)
                {
                    message += " " + command[ii];
                }

                UnturnedChat.Say(otherUplayer, caller.DisplayName + " has whisped to you:" + message);
                UnturnedChat.Say(caller, "pm sent to " + otherUplayer.DisplayName);
            }
        }

        public string Help
        {
            get { return "lets you personal message a player"; }
        }

        public string Name
        {
            get { return "pm"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() {"pm"}; }
        }

        public string Syntax
        {
            get { return "<player> (message)"; }
        }
    }
}
