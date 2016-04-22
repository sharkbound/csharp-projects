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
    class CommandSetbalance : IRocketCommand
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

            int value = 0;

            if (!(int.TryParse(command[1], out value)))
            {
                UnturnedChat.Say(caller, "the value: " + command[1] + "is invalid");
                return;
            }

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
                UcTools.instance.Database.SetBalance(otherplayer.Id, value);
                bal = UcTools.instance.Database.GetBalance(otherplayer.Id);
            }
            else if (isUlong)
            {
                UcTools.instance.Database.SetBalance(command[0], value);
                bal = UcTools.instance.Database.GetBalance(id.ToString());
            }

            if (foundPlayer)
            {
                UnturnedChat.Say(caller, otherplayer.DisplayName + " has had their balance set to " + bal.ToString());
                Logger.Log(otherplayer.DisplayName + " has had their balance set to " + bal.ToString());
            }
            else
            {
                UnturnedChat.Say(caller, id.ToString() + " has had their balance set to " + bal.ToString());
                Logger.Log(id.ToString() + " has had their balance set to " + bal.ToString());
            }

        }

        public string Help
        {
            get { return "sets someones uconomy balance"; }
        }

        public string Name
        {
            get { return "setbal"; }
        }

        public List<string> Permissions
        {
            get { return new List<string> { "setbal" }; }
        }

        public string Syntax
        {
            get { return "<player> <amount to set balance to>"; }
        }
    }
}
