using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Unturned.Player;
using Rocket.Core.Logging;
using Rocket.API;
using Rocket.Unturned.Chat;

namespace godmodeAnnouncer
{
    class VC : IRocketCommand
    {
        public List<string> Aliases
        {
            get
            {
                return new List<string> ();
            }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return Rocket.API.AllowedCaller.Both;
            }
        }

        public string Help
        {
            get
            {
                return "Check if player is in vanish";
            }
        }

        public string Name
        {
            get
            {
                return "vc";
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string> { "vc" };
            }
        }

        public string Syntax
        {
            get
            {
                return "<player>";
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length != 1)
            {
                UnturnedChat.Say(caller, "You must enter a player name!");
                return;
            }

            UnturnedPlayer otherPlayer = UnturnedPlayer.FromName(command[0]);
            if (otherPlayer == null)
            {
                UnturnedChat.Say(caller, "Could not find player by the name of " + command[0]);
                return;
            }

            if (otherPlayer.Features.VanishMode)
            {
                if (caller is ConsolePlayer)
                {
                    Logger.Log("The player " + otherPlayer.DisplayName + " is in vanish"); 
                }
                else
                {
                    Logger.Log("The player " + otherPlayer.DisplayName + " is in vanish"); 
                    UnturnedChat.Say(caller, "The player " + otherPlayer.DisplayName + " is in vanish"); 
                }
            }
            else
            {
                if (caller is ConsolePlayer)
                {
                    Logger.Log("The player " + otherPlayer.DisplayName + " is NOT vanish");
                }
                else
                {
                    Logger.Log("The player " + otherPlayer.DisplayName + " is NOT vanish");
                    UnturnedChat.Say(caller, "The player " + otherPlayer.DisplayName + " is NOT vanish");
                }
            }
        }
    }
}
