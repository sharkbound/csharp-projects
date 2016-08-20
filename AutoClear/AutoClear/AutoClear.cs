using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Core.Commands;
using SDG.Unturned;
using System.Threading;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using Rocket.API;
using Steamworks;
using SDG.Provider;

namespace AutoClear
{
    public class AutoClear : RocketPlugin<Config>
    {
        bool matchesSpamPoint = false;
        public static Dictionary<InteractableVehicle, DateTime> VehicleData = new Dictionary<InteractableVehicle, DateTime>();
        public static List<CSteamID> chatLogPlayers = new List<CSteamID>();
        public static AutoClear Instance;
        List<InteractableVehicle> toRemove = new List<InteractableVehicle>();
        List<InteractableVehicle> updateDateTime = new List<InteractableVehicle>();
        Dictionary<CSteamID, string> lastMessages = new Dictionary<CSteamID, string>();
        Dictionary<CSteamID, int> sameMessageCount = new Dictionary<CSteamID, int>();
        //List<InteractableVehicle> nullVehicles = new List<InteractableVehicle>();

        protected override void Load()
        {
            Instance = this;
            UnturnedPlayerEvents.OnPlayerChatted += UnturnedPlayerEvents_OnPlayerChatted;
            UnturnedPlayerEvents.OnPlayerDeath += UnturnedPlayerEvents_OnPlayerDeath;
            if (Instance.Configuration.Instance.ClearVehicleDestoryListOnReload)
            {
                toRemove = new List<InteractableVehicle>();
                VehicleData = new Dictionary<InteractableVehicle, DateTime>();
                updateDateTime = new List<InteractableVehicle>();
            }
          /*  lastMessages = new Dictionary<CSteamID, string>();
            sameMessageCount = new Dictionary<CSteamID, int>();
            chatLogPlayers = new List<CSteamID>();  */
            Logger.Log("AutoClear has loaded!");
        }

        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDeath -= UnturnedPlayerEvents_OnPlayerDeath;
            UnturnedPlayerEvents.OnPlayerChatted -= UnturnedPlayerEvents_OnPlayerChatted;
            Logger.Log("AutoClear has Unloaded!");
        }

        void UnturnedPlayerEvents_OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            if (murderer == null || player == null) return;

            UnturnedPlayer P = UnturnedPlayer.FromCSteamID(murderer);
            if (P == null) return;

            try
            {
                if (P.Features.GodMode && (P.HasPermission("god") || P.HasPermission("godmode")))
                {
                    UnturnedChat.Say("'" + P.DisplayName + "' killed '" + player.DisplayName + "' while in Godmode!", UnityEngine.Color.red);
                    Logger.LogWarning("'" + P.DisplayName + "' killed '" + player.DisplayName + "' while in Godmode!");
                }
            }
            catch
            {
            }
        }

        public override Rocket.API.Collections.TranslationList DefaultTranslations
        {
            get
            {
                return new Rocket.API.Collections.TranslationList
                {
                    {"command_v_giving_console", "Giving {0} vehicle {1} ({2})"},
                    {"command_v_giving_private", "Giving you a {0} ({1})"},
                    {"command_v_giving_failed_private", "Failed giving you a {0} ({1})"},
                    {"command_generic_invalid_parameter", "Invalid parameter"}
                };
            }
        }

        void UnturnedPlayerEvents_OnPlayerChatted(Rocket.Unturned.Player.UnturnedPlayer player, ref UnityEngine.Color color, string message, EChatMode chatMode, ref bool cancel)
        {
            if (matchesSpamPoint) matchesSpamPoint = false;
            if (!lastMessages.ContainsKey(player.CSteamID)) lastMessages.Add(player.CSteamID, message);
            if (!sameMessageCount.ContainsKey(player.CSteamID)) sameMessageCount.Add(player.CSteamID, 0);
            if (message == lastMessages[player.CSteamID])
            {
                IRocketPlayer rPlayer;
                if (!((IRocketPlayer)player).HasPermission("bypassspamwarning"))
                {
                    sameMessageCount[player.CSteamID]++; 
                }

                //Logger.LogError("Spam found. Count: " + sameMessageCount[player.CSteamID]);

                if (Instance.Configuration.Instance.SpamWarningPoints.Contains(sameMessageCount[player.CSteamID]))
                {
                    matchesSpamPoint = true;
                }

                if (matchesSpamPoint)
                {
                    foreach (SteamPlayer p in Provider.Players)
                    {
                        rPlayer = (IRocketPlayer)UnturnedPlayer.FromSteamPlayer(p);
                        if (rPlayer.HasPermission("spamwarning"))
                        {
                            UnturnedChat.Say(rPlayer, "SPAM WARNING: [" + player.DisplayName + "] has spammed \"" + message + "\" " + 
                                sameMessageCount[player.CSteamID] + " times!", UnityEngine.Color.red);
                        }
                    }

                    Logger.LogWarning("SPAM WARNING: [" + player.DisplayName + "] has spammed \"" + message + "\" " +
                                sameMessageCount[player.CSteamID] + " times!");
                }
            }
            else
            {
                sameMessageCount[player.CSteamID] = 0;
                lastMessages[player.CSteamID] = message;
            }

            if (chatLogPlayers.Count == 0 || Instance.Configuration.Instance.SteamIdsToNotLogChat.Contains(player.Id)) return;
            
            if (message.Contains("/"))
            {
                if (message.IndexOf("/") == 0)
                {
                    for (int ii = chatLogPlayers.Count - 1; ii >= 0; ii--)
                    {
                        if (player.CSteamID == chatLogPlayers[ii]) continue;

                        if (chatLogPlayers[ii] == null)
                        {
                            chatLogPlayers.Remove(chatLogPlayers[ii]);
                            continue;
                        }
                        else
                        {
                            UnturnedChat.Say(UnturnedPlayer.FromCSteamID(chatLogPlayers[ii]), "[" + player.DisplayName + "] " + message, UnityEngine.Color.blue);
                        }
                    }
                }
            }
        }

        void FixedUpdate()
        {
            foreach (var entry in VehicleData)
            {
               /* InteractableVehicle veh = null;
                if (VehicleManager.Vehicles.Contains(entry.Key))
                {
                   //veh = VehicleManager.Vehicles.Find(vehicle => vehicle.instanceID == entry.Key.instanceID);
                   //veh = entry.Key;
                } */

                if (checkForBarricades(entry.Key, Instance.Configuration.Instance.IgnoreVehiclesWithBarricades) || checkForPassengers(entry.Key))
                {
                    updateDateTime.Add(entry.Key);
                }

                //Logger.Log((DateTime.Now - entry.Value).Seconds.ToString());
                if ((DateTime.Now - entry.Value).Seconds >= Instance.Configuration.Instance.TimeUntilDespawn)
                {
                    if (!checkForBarricades(entry.Key, Instance.Configuration.Instance.IgnoreVehiclesWithBarricades) && !checkForPassengers(entry.Key))
                    {
                        if (AutoClear.Instance.Configuration.Instance.LogClears)
                        {
                            Logger.LogWarning("AutoClearing vehicle: " + entry.Key.asset.vehicleName);
                        }

                        toRemove.Add(entry.Key);
                        VehicleManager.Instance.SteamChannel.send("tellVehicleDestroy",
                                                   ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_INSTANT, entry.Key.instanceID); 
                    }
                }
            }

            foreach (var v in toRemove)
            {
                VehicleData.Remove(v);
            }
            toRemove = new List<InteractableVehicle>();

          /*  for (int ii = toRemove.Count - 1; ii >= 0; ii--)
            {
                toRemove.Remove(toRemove[ii]);
            } */

            for (int jj = updateDateTime.Count - 1; jj >= 0; jj--)
            {
                VehicleData[updateDateTime[jj]] = DateTime.Now;
                updateDateTime.Remove(updateDateTime[jj]);
            }
        }

        public static bool checkForBarricades(InteractableVehicle v, bool ignoreVehiclesWithBarricades)
        {
            byte x;
            byte y;
            ushort plant;
            BarricadeRegion region;
            if (AutoClear.Instance.Configuration.Instance.IgnoreVehiclesWithBarricades)
            {
                if (ignoreVehiclesWithBarricades)
                {
                    if (BarricadeManager.tryGetPlant(v.transform, out x, out y, out plant, out region))
                    {
                        if (region.drops.Count > 0)
                        {
                            return true;
                        }
                    }
                    else { }
                }
            }

            return false;
        }

        public static bool checkForPassengers(InteractableVehicle v)
        {
            foreach (var passenger in v.passengers)
            {
                if (passenger.player == null) { }
                else
                    return true;
            }

            return false;
        }
    }
}
