using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSlots
{
    class Slots : RocketPlugin<SlotsConfig>
    {
        public static Slots Instance;
        byte PreviousMaxPlayers = 24;
        List<Steamworks.CSteamID> SlotsAddedPlayers = new List<Steamworks.CSteamID>();

        protected override void Load()
        {
            Instance = this;
            UnturnedPermissions.OnJoinRequested += UnturnedPermissions_OnJoinRequested;
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;
            Logger.Log("DynamicSlots has loaded!");
        }

        void UnturnedPermissions_OnJoinRequested(Steamworks.CSteamID player, ref SDG.Unturned.ESteamRejection? rejectionReason)
        {
            int playerCount = Provider.clients.Count;

            PreviousMaxPlayers = Provider.maxPlayers;

            if (!UnturnedPlayer.FromCSteamID(player).HasPermission("addslot"))
            {
                return;
            }

            if (playerCount >= Provider.maxPlayers)
            {
                Provider.maxPlayers = byte.Parse((playerCount + 1).ToString());
                SlotsAddedPlayers.Add(player);
            }
        }

        void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            
        }

        void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            if (SlotsAddedPlayers.Contains(player.CSteamID))
            {
                SlotsAddedPlayers.Remove(player.CSteamID);
                if (Provider.maxPlayers > Instance.Configuration.Instance.MaxPlayers)
                {
                    Logger.Log("increased maxPlayers from " + PreviousMaxPlayers.ToString()
                        + " to " + Provider.maxPlayers.ToString());
                    UnturnedChat.Say(player, "increased maxPlayers from " + PreviousMaxPlayers.ToString()
                        + " to " + Provider.maxPlayers.ToString());

                    Provider.maxPlayers = (byte)Instance.Configuration.Instance.MaxPlayers;
                }
            }
        }

        protected override void Unload()
        {
            UnturnedPermissions.OnJoinRequested -= UnturnedPermissions_OnJoinRequested;
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;
            Logger.Log("DynamicSlots has Unloaded!");
        }
    }
}
