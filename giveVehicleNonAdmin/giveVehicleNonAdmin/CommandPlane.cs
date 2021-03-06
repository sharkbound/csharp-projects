﻿using System;
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
            DateTime remainingCooldownDatetime;
            ushort id = (ushort)giveVehicle.instance.Configuration.Instance.planeId;
            double maxCooldown = (double)giveVehicle.instance.Configuration.Instance.SpawnCooldown;

            if (!(giveVehicle.IndividualCooldowns.ContainsKey(caller.DisplayName)))
            {
                giveVehicle.IndividualCooldowns.Add(caller.DisplayName, DateTime.Now);
            }

            if (giveVehicle.IndividualCooldowns.TryGetValue(caller.DisplayName, out remainingCooldownDatetime))
            {
                if ((DateTime.Now - remainingCooldownDatetime).TotalSeconds >= maxCooldown || giveVehicle.FirstCommandExecution[caller.DisplayName] == true )
                {
                    if (VehicleTool.giveVehicle(Ucaller.Player, id))
                    {
                        UnturnedChat.Say(Ucaller, giveVehicle.instance.Translations.Instance.Translate("Command_plane_give_private"), UnityEngine.Color.yellow);
                        giveVehicle.IndividualCooldowns[caller.DisplayName] = DateTime.Now;
                        if (giveVehicle.FirstCommandExecution[caller.DisplayName])
                        {
                            giveVehicle.FirstCommandExecution[caller.DisplayName] = false;
                        }
                    }
                }
                else
                {
                    double cooldown = maxCooldown - (DateTime.Now - remainingCooldownDatetime).TotalSeconds;
                    UnturnedChat.Say(Ucaller, "you have to wait " + (int)cooldown + " seconds to use this command again", UnityEngine.Color.yellow);
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
