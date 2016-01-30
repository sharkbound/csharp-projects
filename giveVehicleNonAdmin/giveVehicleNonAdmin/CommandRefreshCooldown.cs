using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using SDG.Unturned;


namespace giveVehicleNonAdmin
{
    class CommandRefreshCooldown : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Both; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer Uplayer = UnturnedPlayer.FromName(command[0]);
            if (Uplayer == null)
            {
                UnturnedChat.Say(caller, "player not found");
                return;
            }

            if (command.Length != 1)
            {
                UnturnedChat.Say(caller, "invalid parameter");
            }

            if (giveVehicle.FirstCommandExecution.ContainsKey(caller.DisplayName))
            {
                UnturnedChat.Say(Uplayer, "your vehicle spawn cooldown has been reset", UnityEngine.Color.yellow);
                giveVehicle.FirstCommandExecution[Uplayer.DisplayName] = true;
            }
        }

        public string Help
        {
            get { return "refreshes the players vehicles cooldown"; }
        }

        public string Name
        {
            get { return "rcd"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() { "refeshcooldown" }; }
        }

        public string Syntax
        {
            get { return "<player>"; }
        }
    }
}
