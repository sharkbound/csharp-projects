using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Rocket.API;
using Rocket.Core;
using Rocket.Unturned;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned.Events;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using Steamworks;


namespace spawnprotection
{
    public class spawnProtection : RocketPlugin<SpawnProtectionConfig>
    {
        public static spawnProtection Instance;
        public static Dictionary<CSteamID, Thread> ProtectedPlayers = new Dictionary<CSteamID, Thread>();

        protected override void Load()
        {
            Instance = this;

            UnturnedPlayerEvents.OnPlayerRevive += UnturnedPlayerEvents_OnPlayerRevive;
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;

            Logger.Log("SpawnProtection loaded!");
            Logger.Log("Spawn protection duration : " + Instance.Configuration.Instance.ProtectionTime.ToString());
            Logger.Log("Spawn protection delay : " + Instance.Configuration.Instance.ProtectionDelay.ToString());
            Logger.Log("Spawn sleep time : " + Instance.Configuration.Instance.SleepTime.ToString());
        }


        protected override void Unload()
        {
            List<CSteamID> playersToRemove = new List<CSteamID>();

            Logger.Log("SpawnProtection Unloaded!");

            UnturnedPlayerEvents.OnPlayerRevive -= UnturnedPlayerEvents_OnPlayerRevive;
            U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;

            foreach (var t in ProtectedPlayers)
            {
                t.Value.Abort();
            }

            UnturnedPlayer p = null;
            foreach (var player in ProtectedPlayers)
            {
                p = UnturnedPlayer.FromCSteamID(player.Key);
                if (p == null)
                {
                    continue;
                }

                if (p.Features.GodMode)
                {
                    UnturnedChat.Say(player.Key, "You no longer have spawn protection!");

                    p.Features.GodMode = false;

                    playersToRemove.Add(player.Key);
                }
            }

            int count = 0;

            foreach (var ID in playersToRemove)
            {
                count++;

                ProtectedPlayers.Remove(ID);
            }

            playersToRemove = new List<CSteamID>();
        }

        void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            if (ProtectedPlayers.ContainsKey(player.CSteamID))
            {
                ProtectedPlayers[player.CSteamID].Abort();
                ProtectedPlayers.Remove(player.CSteamID);
            }
        }


        void UnturnedPlayerEvents_OnPlayerRevive(UnturnedPlayer player, UnityEngine.Vector3 position, byte angle)
        {
            addSpawnProtectionPlayer(player);
        }

        void addSpawnProtectionPlayer(UnturnedPlayer player)
        {
            Thread t = null;
            t = new Thread(() =>
                {
                    bool equiptedItem = false;
                    double compeletedSleepTime = 0;

                    UnturnedChat.Say(player, "You have spawn protection for " + Instance.Configuration.Instance.ProtectionTime.ToString() + " seconds!");
                    player.Features.GodMode = true;

                    Thread.Sleep(Configuration.Instance.ProtectionDelay);

                    int protectionTimeMiliseconds = Configuration.Instance.ProtectionTime * 1000;
                    while (compeletedSleepTime < protectionTimeMiliseconds)
                    {
                        if (player.Player.equipment.asset != null)
                        {
                            equiptedItem = true;
                            break;
                        }

                        Thread.Sleep(Configuration.Instance.SleepTime);
                        compeletedSleepTime += Configuration.Instance.SleepTime;
                        //Logger.LogError("current sleep time: " + compeletedSleepTime + ", Total protection time milliseconds: " + protectionTimeMiliseconds);
                    }

                    if (equiptedItem)
                    {
                        UnturnedChat.Say(player, "Your spawn protection expired because you equipted a item!"); 
                    }
                    else
                    {
                        UnturnedChat.Say(player, "Your spawn protection has expired!"); 
                    }

                    player.Features.GodMode = false;

                    ProtectedPlayers.Remove(player.CSteamID);
                    t.Abort();

                })
                {
                    IsBackground = true
                };
            t.Start();

            ProtectedPlayers.Add(player.CSteamID, t);
        }

        
    }
}
