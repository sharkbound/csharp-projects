using Rocket.API;
using Rocket.API.Extensions;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using System;

namespace AutoClear
{
    class CommandListV : IRocketCommand
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
            string message = "";

            if (VehicleManager.vehicles.Count == 1)
            {
                message = "There is currently " + VehicleManager.vehicles.Count.ToString() + " vehicle.";
            }
            else
            {
                message = "There is currently " + VehicleManager.vehicles.Count.ToString() + " vehicles.";
            }

            if (!(caller is ConsolePlayer))
            {
                UnturnedChat.Say(caller, message);
            }

            Logger.LogWarning(message);
        }

        public string Help
        {
            get { return "tells the amount of vehicles currently on the map."; }
        }

        public string Name
        {
            get { return "listv"; }
        }

        public List<string> Permissions
        {
            get { return new List<string> { "listv" }; }
        }

        public string Syntax
        {
            get { return ""; }
        }
    }
}
