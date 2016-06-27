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


namespace spawnprotection
{
    public class spawnProtection : RocketPlugin<SpawnProtectionConfig>
    {
        public static spawnProtection Instance;
        public static Dictionary<UnturnedPlayer, Thread> ProtectedPlayers = new Dictionary<UnturnedPlayer, Thread>();

        protected override void Load()
        {
            Instance = this;

            UnturnedPlayerEvents.OnPlayerRevive += UnturnedPlayerEvents_OnPlayerRevive;
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;

            Logger.Log("SpawnProtection loaded!");
            Logger.Log("Spawn protection duration : " + Instance.Configuration.Instance.SpawnProtectionDuration.ToString());
        }


        protected override void Unload()
        {
            List<UnturnedPlayer> playersToRemove = new List<UnturnedPlayer>();

            Logger.Log("SpawnProtection Unloaded!");

            UnturnedPlayerEvents.OnPlayerRevive -= UnturnedPlayerEvents_OnPlayerRevive;
            U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;

            foreach (var t in ProtectedPlayers)
            {
                t.Value.Abort();
            }

            foreach (var player in ProtectedPlayers)
            {
                if (player.Key.Features.GodMode)
                {
                    UnturnedChat.Say(player.Key, "You are no longer have spawn protection!");

                    player.Key.Features.GodMode = false;

                    playersToRemove.Add(player.Key);
                }
            }

            int count = 0;

            foreach (UnturnedPlayer Uplayer in playersToRemove)
            {
                count++;

                Logger.Log("removing : " + Uplayer.DisplayName);
                ProtectedPlayers.Remove(Uplayer);
            }

            playersToRemove.RemoveRange(0, count);
        }

        void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            Logger.Log("yessir");
            if (ProtectedPlayers.ContainsKey(player))
            {
                Logger.Log("1");
                foreach (var key in ProtectedPlayers)
                {
                    Logger.Log("2");
                    if (key.Key == player)
                    {
                        Logger.LogError("disconnecting player has a key.");
                        key.Key.Features.GodMode = false;
                        key.Value.Abort();
                        ProtectedPlayers.Remove(player);
                    }
                }
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
                    UnturnedChat.Say(player, "You have spawn protection for " + Instance.Configuration.Instance.SpawnProtectionDuration.ToString() + " seconds!");
                    player.Features.GodMode = true;

                    Thread.Sleep(Instance.Configuration.Instance.SpawnProtectionDuration * 1000);

                    UnturnedChat.Say(player, "Your spawn protection has expired!");
                    player.Features.GodMode = false;

                    ProtectedPlayers.Remove(player);
                    t.Abort();

                })
                {
                    IsBackground = true
                };
            t.Start();


            ProtectedPlayers.Add(player, t);
        }

        
    }
}
