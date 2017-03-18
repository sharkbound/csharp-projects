using Rocket.API;
using Rocket.API.Extensions;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using System;

namespace Rocket.Unturned.Commands
{
    public class CommandB : IRocketCommand
    {
        public AllowedCaller AllowedCaller
        {
            get
            {
                return AllowedCaller.Player;
            }
        }

        public string Name
        {
            get { return "b"; }
        }

        public string Help
        {
            get { return "Gives yourself an vehicle"; }
        }

        public string Syntax
        {
            get { return "<id> or <\"vehicle name\">"; }
        }

        public List<string> Aliases
        {
            get { return new List<string> { "v" }; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() { "b" }; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length == 0)
            {
                UnturnedChat.Say(caller, "incorrect usage! Correct usage: " + Syntax);
                return;
            }

            List<InteractableVehicle> foundVehicles = new List<InteractableVehicle>();
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if (command.Length != 1)
            {
                UnturnedChat.Say(caller, U.Translate("command_generic_invalid_parameter"));
                throw new WrongUsageOfCommandException(caller, this);
            }

            ushort? id = command.GetUInt16Parameter(0);

            if (!id.HasValue)
            {
                string itemString = command.GetStringParameter(0);

                if (itemString == null)
                {
                    UnturnedChat.Say(caller, U.Translate("command_generic_invalid_parameter"));
                    throw new WrongUsageOfCommandException(caller, this);
                }

                Asset[] assets = SDG.Unturned.Assets.find(EAssetType.VEHICLE);
                foreach (VehicleAsset ia in assets)
                {
                    if (ia != null && ia.vehicleName != null && ia.vehicleName.ToLower().Contains(itemString.ToLower()))
                    {
                        id = ia.id;
                        break;
                    }
                }
                if (!id.HasValue)
                {
                    UnturnedChat.Say(caller, U.Translate("command_generic_invalid_parameter"));
                    throw new WrongUsageOfCommandException(caller, this);
                }
            }

            Asset a = SDG.Unturned.Assets.find(EAssetType.VEHICLE, id.Value);
            string assetName = ((VehicleAsset)a).vehicleName;

            // see if blacklist is enabled
            if (AutoClear.AutoClear.Instance.Configuration.Instance.BlacklistEnabled && !caller.HasPermission("bypassvehicleblacklist"))
            {
                //check if the entered vehicle is blacklisted
                if (AutoClear.AutoClear.Instance.Configuration.Instance.BlacklsitedVehicleIds.Contains(id.Value.ToString()))
                {
                    UnturnedChat.Say(caller, "The vehicle \"" + assetName + "\" ID: " + id.Value.ToString() + " is Blacklisted!");
                    return;
                } 
            }

            if (VehicleTool.giveVehicle(player.Player, id.Value))
            {
                VehicleManager.getVehiclesInRadius(((UnturnedPlayer)caller).Position, 
                    AutoClear.AutoClear.Instance.Configuration.Instance.Radius, foundVehicles);
                for (int j = foundVehicles.Count - 1; j >= 0; j--)
                {
                    if (!AutoClear.AutoClear.VehicleData.ContainsKey(foundVehicles[j]))
                    {
                        AutoClear.AutoClear.VehicleData.Add(foundVehicles[j], DateTime.Now);
                    }
                }
                Logger.Log(AutoClear.AutoClear.Instance.Translate("command_v_giving_console", player.CharacterName, id, assetName));
                UnturnedChat.Say(caller, U.Translate("command_v_giving_private", assetName, id));
            }
            else
            {
                UnturnedChat.Say(caller, U.Translate("command_v_giving_failed_private", assetName, id));
            }
        }

        
    }
}