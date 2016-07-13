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
    class AdminTp : IRocketCommand
    {
        public List<string> Aliases
        {
            get
            {
                return new List<string> {"atp"};
            }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return Rocket.API.AllowedCaller.Player;
            }
        }

        public string Help
        {
            get
            {
                return "Vanishes and tp's you to a player";
            }
        }

        public string Name
        {
            get
            {
                return "AdminTp";
            }
        }

        public List<string> Permissions 
        {
            get
            {
                return new List<string> { "admintp" };
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

            UnturnedPlayer player = (UnturnedPlayer)caller;
            if (player == null)
            {
                return;
            }

            UnturnedPlayer otherPlayer = UnturnedPlayer.FromName(command[0]);
            if (otherPlayer == null)
            {
                UnturnedChat.Say(caller, "Could not find player by the name of " + command[0]);
                return;
            }

            player.Features.VanishMode = true;
            player.Teleport(otherPlayer);

            UnturnedChat.Say(caller, "You AdminTP'd to " + otherPlayer.DisplayName);
            Logger.Log("Player " + player.DisplayName + " AdminTp'd to " + otherPlayer.DisplayName);
        }
    }
}
