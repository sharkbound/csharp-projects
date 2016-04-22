using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;

namespace uconomytools
{
    class CommandCheckbalance : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string> { }; }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Both; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            bool foundPlayer = false;
            bool isUlong = false;

            ulong id = 0;
            decimal bal = 0;

            UnturnedPlayer otherplayer = UnturnedPlayer.FromName(command[0]);
            if (!(otherplayer == null))
            {
                foundPlayer = true;
            }
            else if (ulong.TryParse(command[0], out id))
            {
                isUlong = true;
            }
            else
            {
                UnturnedChat.Say(caller, "player not found!");
                return;
            }

            if (foundPlayer)
            {
               bal = UcTools.instance.Database.GetBalance(otherplayer.Id);
            }
            else if (isUlong)
            {
               bal = UcTools.instance.Database.GetBalance(command[0]);
            }

            if (foundPlayer)
            {
                UnturnedChat.Say(caller, otherplayer.DisplayName + " has the balance of " + bal.ToString());
                Logger.Log(otherplayer.DisplayName + " has the balance of " + bal.ToString()); 
            }
            else
            {
                UnturnedChat.Say(caller, id.ToString() + " has the balance of " + bal.ToString());
                Logger.Log(id.ToString() + " has the balance of " + bal.ToString());
            }

        }

        public string Help
        {
            get { return "shows someones uconomy balance"; }
        }

        public string Name
        {
            get { return "checkbal"; }
        }

        public List<string> Permissions
        {
            get { return new List<string> { "checkbal" }; }
        }

        public string Syntax
        {
            get { return "<player>"; }
        }
    }
}
