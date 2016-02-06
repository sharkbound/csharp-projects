using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using UnityEngine;
using SDG.Unturned;

namespace giveVehicleNonAdmin
{
    class CommandFill : IRocketCommand
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
            bool successfullExecution = false;
            bool hasIntValueOnFirstPara = false;
            bool hasIntValueOnSecondPara = false;

            int fillCount = 0;
            int fuel = giveVehicle.instance.Configuration.Instance.defaultFuel;
            int radius = giveVehicle.instance.Configuration.Instance.defaultRadius;

            if (command.Length < 1 || command.Length > 2)
            {
                UnturnedChat.Say(caller, "invalid or missing parameter, /fill [<radius> : all] (fuel)");
                return;
            }

            if (command.Length == 1 || command.Length == 2)
            {
                if (int.TryParse(command[0], out radius))
                {
                    hasIntValueOnFirstPara = true;
                } 
            }

            if (command.Length == 2)
            {
                if (int.TryParse(command[1], out fuel))
                {
                    hasIntValueOnSecondPara = true;
                } 
            }

            foreach (var vh in VehicleManager.Vehicles)
            {
                if (hasIntValueOnFirstPara)
                {
                    Vector3 vehicleVector3 = vh.transform.position;
                    if (Vector3.Distance(vehicleVector3, ((UnturnedPlayer)caller).Player.transform.position) <= radius)
                    {
                        successfullExecution = true;
                        vh.askFill((ushort)fuel);
                        fillCount++;
                    }
                }
                else if (command[0].ToLower() == "all")
                {
                    successfullExecution = true;
                    vh.askFill((ushort)fuel);
                    fillCount++;
                }
                else
                {
                    UnturnedChat.Say(caller, "invalid or missing parameter, /fill [<radius> : all] (fuel)");
                    return;
                }
            }

            if (successfullExecution)
            {
                if (radius == 0)
                {
                    UnturnedChat.Say(caller, "filled " + fillCount + " vehicles in a " + giveVehicle.instance.Configuration.Instance.defaultRadius + " radius!");
                    Logger.Log("filled " + fillCount + " vehicles in a " + giveVehicle.instance.Configuration.Instance.defaultRadius + " radius!"); 
                }
                else
                {
                    UnturnedChat.Say(caller, "filled " + fillCount + " vehicles in a " + radius + " radius!");
                    Logger.Log("filled " + fillCount + " vehicles in a " + radius + " radius!"); 
                }
            }
        }

        public string Help
        {
            get { return "fills vehicles fuel"; }
        }

        public string Name
        {
            get { return "fill"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() { "fill" }; }
        }

        public string Syntax
        {
            get { return "[<radius> : all] (fuel)"; }
        }
    }
}
