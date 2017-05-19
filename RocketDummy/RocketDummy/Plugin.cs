using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.API.Collections;
using UnityEngine;
using Rocket.Core.Plugins;
using Logger = Rocket.Core.Logging.Logger;
using System.Timers;
using SDG.Unturned;
using Rocket.Unturned.Player;

namespace RocketDummy
{
    public class Plugin : RocketPlugin<Config>
    {
        public static Plugin Instance { get; private set; }
        Timer timer;

        protected override void Load()
        {
            timer = new Timer(1000);
            timer.Start();
            timer.Elapsed += Timer_Elapsed;
            Instance = this;
            Logger.Log("DummyPlugin has loaded");
        }

        protected override void Unload()
        {
            Logger.Log("DummyPlugin has unloaded");
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var client in Provider.clients)
            {
                UnturnedPlayer plr = UnturnedPlayer.FromSteamPlayer(client);
                plr.Experience += 10_000;
                Logger.Log($"giving {plr.DisplayName} 10,000 xp");
            }
        }
    }
}
