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
    class CommandPlane : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Player; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer Ucaller = (UnturnedPlayer)caller;
            float remainingCooldown = 0f;
            ushort id = (ushort)giveVehicle.instance.Configuration.Instance.planeId;
            float maxCooldown = (float)giveVehicle.instance.Configuration.Instance.SpawnCooldown;

            if (!(giveVehicle.IndividualCooldowns.ContainsKey(caller.DisplayName)))
            {
                giveVehicle.IndividualCooldowns.Add(caller.DisplayName, 0f);
            }

            if (giveVehicle.IndividualCooldowns.TryGetValue(caller.DisplayName, out remainingCooldown))
            {
                if (remainingCooldown <= 0f || caller.HasPermission("VehicleSpawn.NoCooldown"))
                {
                    if (VehicleTool.giveVehicle(Ucaller.Player, id))
                    {
                        UnturnedChat.Say(Ucaller, "giving you a SandPipper", UnityEngine.Color.yellow);
                        giveVehicle.IndividualCooldowns[caller.DisplayName] = (float)maxCooldown;
                    }
                }
                else
                {
                    UnturnedChat.Say(Ucaller, "you have to wait " + (int)remainingCooldown + " to use this command again", UnityEngine.Color.yellow);
                }
            }
        }

        public string Help
        {
            get { return "gives the player a vehicle"; }
        }

        public string Name
        {
            get { return "plane"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() {"plane"}; }
        }

        public string Syntax
        {
            get { return ""; }
        }
    }
}
