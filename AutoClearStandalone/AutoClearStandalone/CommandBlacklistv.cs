using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using Rocket.Core.Logging;
using SDG.Unturned;
using Rocket.API.Extensions;

namespace AutoClear
{
    class CommandBlacklistv : IRocketCommand
    {
        string InvalidUsage = "Wrong usage, correct usage: [add | rem] [vehicle name or id]";
        string NoVehicleFound = "Could not find a vehicle with the given name or id!";

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
            if (command.Length != 2)
            {
                sendMsg(InvalidUsage, caller);
                return;
            }

            if (command[0].ToLower() == "add")
            {
                SDG.Unturned.Asset asset;
                asset = getVehicle(command[1], caller, command);
                if (asset == null)
                {
                    return;
                }

                if (!AutoClear.Instance.Configuration.Instance.BlacklsitedVehicleIds.Contains(asset.id.ToString()))
                {
                    AutoClear.Instance.Configuration.Instance.BlacklsitedVehicleIds.Add(asset.id.ToString());
                    AutoClear.Instance.Configuration.Save();
                    sendMsg("Added \"" + asset.name + "\" ID: " + asset.id.ToString() + " to the vehicle blacklist!", caller);
                }
                else
                {
                    sendMsg("The vehicle \"" + asset.name + "\" ID: " + asset.id.ToString() + " is already in the blacklist!", caller);
                }
            }
            else if (command[0].ToLower() == "rem")
            {
                SDG.Unturned.Asset asset;
                asset = getVehicle(command[1], caller, command);
                if (asset == null)
                {
                    return;
                }

                if (AutoClear.Instance.Configuration.Instance.BlacklsitedVehicleIds.Contains(asset.id.ToString()))
                {
                    AutoClear.Instance.Configuration.Instance.BlacklsitedVehicleIds.Remove(asset.id.ToString());
                    AutoClear.Instance.Configuration.Save();
                    sendMsg("Removed \"" + asset.name + "\" ID: " + asset.id.ToString() + " from blacklisted vehicles!", caller);
                }
                else
                {
                    sendMsg("The vehicle \"" + asset.name + "\" ID: " + asset.id.ToString() + " is not in the blacklist!", caller);
                }
            }
        }

        void sendMsg(string message, IRocketPlayer caller)
        {
            if (caller is ConsolePlayer)
                Logger.Log(message);
            else
                UnturnedChat.Say(caller, message);
        }

        SDG.Unturned.Asset getVehicle(string vehicle, IRocketPlayer caller, string[] command)
        {
            ushort? id = command.GetUInt16Parameter(1);

            if (!id.HasValue)
            {
                string itemString = command.GetStringParameter(1);

                if (itemString == null)
                {
                    sendMsg(InvalidUsage, caller);
                    return null;
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
                    sendMsg(NoVehicleFound, caller);
                    return null;
                }
            }

            return SDG.Unturned.Assets.find(EAssetType.VEHICLE, id.Value);
        }

        public string Help
        {
            get { return "add a vehicle id to blacklist"; }
        }

        public string Name
        {
            get { return "blacklistv"; }
        }

        public List<string> Permissions
        {
            get { return new List<string> { "blacklistv" }; }
        }

        public string Syntax
        {
            get { return "[add | rem] [vehicle name or id]"; }
        }
    }
}
